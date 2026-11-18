using Avalonia.Data.Converters;
using ServiceLib.Models.Entities;

namespace v2rayN.Desktop.Converters;

public class SubItemLabelConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not SubItem item)
        {
            return value?.ToString() ?? string.Empty;
        }

        if (item.Remarks.IsNotEmpty())
        {
            return item.Remarks;
        }
        if (item.Url.IsNotEmpty())
        {
            return item.Url;
        }
        return "Unnamed subscription";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
