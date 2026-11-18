using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class DelayTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var text = value?.ToString();
        if (text.IsNullOrEmpty() || text.ToInt() <= 0)
        {
            return "Untested";
        }
        return $"{text} ms";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
