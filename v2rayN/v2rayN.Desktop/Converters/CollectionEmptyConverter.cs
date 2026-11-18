using System.Collections;
using System.Globalization;
using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class CollectionEmptyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value switch
        {
            ICollection collection => collection.Count == 0,
            int count => count == 0,
            _ => true
        };
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
