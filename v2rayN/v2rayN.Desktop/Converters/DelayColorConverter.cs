using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class DelayColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var delay = value.ToString().ToInt();

        return delay switch
        {
            <= 0 => new SolidColorBrush(Color.Parse("#FF64748B")),
            <= 300 => new SolidColorBrush(Color.Parse("#FF10B981")),
            <= 800 => new SolidColorBrush(Color.Parse("#FFF59E0B")),
            _ => new SolidColorBrush(Color.Parse("#FFF87171"))
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
