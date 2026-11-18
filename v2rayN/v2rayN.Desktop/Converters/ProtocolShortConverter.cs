using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class ProtocolShortConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value?.ToString() switch
        {
            "Shadowsocks" => "SS",
            "Hysteria2" => "HY2",
            "WireGuard" => "WG",
            "AnyTLS" or "Anytls" => "ANYTLS",
            "VMess" => "VMESS",
            _ => value?.ToString()?.ToUpperInvariant() ?? string.Empty
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
