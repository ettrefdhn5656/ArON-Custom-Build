using Avalonia.Data.Converters;

namespace v2rayN.Desktop.Converters;

public class JoinTextConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var separator = parameter as string ?? " · ";

        return string.Join(separator, values
            .Where(value => value is string text && !string.IsNullOrWhiteSpace(text))
            .Select(value => value!.ToString()));
    }
}
