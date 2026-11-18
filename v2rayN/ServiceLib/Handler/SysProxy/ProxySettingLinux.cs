namespace ServiceLib.Handler.SysProxy;

[SupportedOSPlatform("linux")]
public static class ProxySettingLinux
{
    private static readonly string _proxySetFileName = $"{Global.ProxySetLinuxShellFileName.Replace(Global.NamespaceSample, "")}.sh";

    public static async Task SetProxy(string host, int port, string exceptions)
    {
        List<string> args = ["manual", host, port.ToString(), exceptions];
        await ExecCmd(args);
    }

    public static async Task UnsetProxy()
    {
        List<string> args = ["none"];
        await ExecCmd(args);
    }

    private static async Task ExecCmd(List<string> args)
    {
        var customSystemProxyScriptPath = AppManager.Instance.Config.SystemProxyItem?.CustomSystemProxyScriptPath;
        var fileName = (customSystemProxyScriptPath.IsNotEmpty() && File.Exists(customSystemProxyScriptPath))
            ? customSystemProxyScriptPath
            : await FileUtils.CreateLinuxShellFile(_proxySetFileName, EmbedUtils.GetEmbedText(Global.ProxySetLinuxShellFileName), false);

        var message = fileName == customSystemProxyScriptPath
            ? $"Custom system proxy script - {Path.GetFileName(fileName)}"
            : $"System proxy script - {Path.GetFileName(fileName)}";
        NoticeManager.Instance.SendMessageEx(message);

        await Utils.GetCliWrapOutput(fileName, args);
    }
}
