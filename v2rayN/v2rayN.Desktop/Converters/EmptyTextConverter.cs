using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class EmptyTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var text = value?.ToString();
        if (text.IsNullOrEmpty())
        {
            return parameter?.ToString() ?? "Default";
        }
        return text;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
