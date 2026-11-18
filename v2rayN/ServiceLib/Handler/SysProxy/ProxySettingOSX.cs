using System.Text.Json;

namespace ServiceLib.Handler.SysProxy;

[SupportedOSPlatform("macos")]
public static class ProxySettingOSX
{
    private static readonly string _proxySetFileName = $"{Global.ProxySetOSXShellFileName.Replace(Global.NamespaceSample, "")}.sh";
    private static readonly string _tunDnsAddress = "1.1.1.1";
    private static readonly string _tunDnsBackupFile = Utils.GetConfigPath("mac_tun_dns_backup.json");

    public static async Task SetProxy(string host, int port, string exceptions)
    {
        List<string> args = ["set", host, port.ToString()];
        if (exceptions.IsNotEmpty())
        {
            args.AddRange(exceptions.Split(','));
        }

        await ExecCmd(args);
    }

    public static async Task UnsetProxy()
    {
        List<string> args = ["clear"];
        await ExecCmd(args);
    }

    /// <summary>
    /// The ISP's on-link DNS servers (both IPv4 and IPv6) sit on directly-connected
    /// subnets that outrank the TUN's default routes, so their poisoned answers bypass
    /// sing-box's hijack-dns entirely. While the TUN is up, point every network
    /// service's DNS at an address that is routed into the TUN, where hijack-dns
    /// answers it; the previous settings are restored by <see cref="RestoreTunDns"/>.
    /// </summary>
    public static async Task SetTunDns()
    {
        await RestoreTunDns();

        var backup = new Dictionary<string, List<string>>();
        foreach (var service in await ListNetworkServices())
        {
            var servers = await GetDnsServers(service);
            if (servers == null)
            {
                continue;
            }

            backup[service] = servers;
            if (servers.Count != 1 || servers[0] != _tunDnsAddress)
            {
                await RunNetworkSetup(["setdnsservers", service, _tunDnsAddress]);
            }
        }

        try
        {
            File.WriteAllText(_tunDnsBackupFile, JsonSerializer.Serialize(backup));
        }
        catch (Exception ex)
        {
            Logging.SaveLog("SetTunDns", ex);
        }
    }

    public static async Task RestoreTunDns()
    {
        if (!File.Exists(_tunDnsBackupFile))
        {
            return;
        }

        try
        {
            var backup = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(File.ReadAllText(_tunDnsBackupFile));
            if (backup != null)
            {
                foreach (var (service, servers) in backup)
                {
                    var dnsServers = servers.Count > 0 ? servers : ["EMPTY"];
                    await RunNetworkSetup(["setdnsservers", service, .. dnsServers]);
                }
            }
        }
        catch (Exception ex)
        {
            Logging.SaveLog("RestoreTunDns", ex);
        }
        finally
        {
            File.Delete(_tunDnsBackupFile);
        }
    }

    private static async Task<List<string>> ListNetworkServices()
    {
        var output = await Utils.GetCliWrapOutput("networksetup", ["-listallnetworkservices"]);
        return output?
            .Split('\n')
            .Select(l => l.Trim())
            .Where(l => l.Length > 0 && !l.Contains('*'))
            .ToList() ?? [];
    }

    /// <returns>The configured DNS servers, or null when the service uses DHCP.</returns>
    private static async Task<List<string>?> GetDnsServers(string service)
    {
        var output = await Utils.GetCliWrapOutput("networksetup", ["-getdnsservers", service]);
        if (output == null || output.Contains("There aren't any DNS Servers set"))
        {
            return [];
        }
        return output.Split('\n').Select(l => l.Trim()).Where(l => l.Length > 0).ToList();
    }

    private static async Task RunNetworkSetup(IEnumerable<string> args)
    {
        await Utils.GetCliWrapOutput("networksetup", args);
    }

    private static async Task ExecCmd(List<string> args)
    {
        var customSystemProxyScriptPath = AppManager.Instance.Config.SystemProxyItem?.CustomSystemProxyScriptPath;
        var fileName = (customSystemProxyScriptPath.IsNotEmpty() && File.Exists(customSystemProxyScriptPath))
            ? customSystemProxyScriptPath
            : await FileUtils.CreateLinuxShellFile(_proxySetFileName, EmbedUtils.GetEmbedText(Global.ProxySetOSXShellFileName), false);

        var message = fileName == customSystemProxyScriptPath
            ? $"Custom system proxy script - {Path.GetFileName(fileName)}"
            : $"System proxy script - {Path.GetFileName(fileName)}";
        NoticeManager.Instance.SendMessageEx(message);

        await Utils.GetCliWrapOutput(fileName, args);
    }
}
