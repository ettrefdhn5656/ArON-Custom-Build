namespace v2rayN.Desktop.Common;

public static class AppBuilderExtension
{
    private static readonly string CjkFontFamilyName =
        Path.Combine(Global.AvaAssets, "Fonts#Noto Sans SC");

    public static AppBuilder WithFontByDefault(this AppBuilder appBuilder)
    {
        // Use the platform's real UI font so the app reads as native, not web.
        var defaultFamilyName = OperatingSystem.IsWindows() ? "Segoe UI" : ".AppleSystemUIFont";

        var fallbacks = new List<FontFallback>
        {
            new() { FontFamily = new FontFamily(CjkFontFamilyName) }
        };

        if (OperatingSystem.IsWindows())
        {
            AddFontFallback(fallbacks, "Segoe UI Emoji");
            AddFontFallback(fallbacks, "Segoe UI Symbol");
            AddFontFallback(fallbacks, "Microsoft YaHei UI");
        }
        else if (OperatingSystem.IsMacOS())
        {
            AddFontFallback(fallbacks, "Apple Color Emoji");
            AddFontFallback(fallbacks, "Apple Symbols");
        }
        else if (OperatingSystem.IsLinux())
        {
            AddFontFallback(fallbacks, "Noto Color Emoji");
            AddFontFallback(fallbacks, "Noto Sans Symbols");
        }

        return appBuilder.With(new FontManagerOptions
        {
            DefaultFamilyName = defaultFamilyName,
            FontFallbacks = fallbacks.ToArray()
        });
    }

    private static void AddFontFallback(List<FontFallback> fallbacks, string fontFamilyName)
    {
        fallbacks.Add(new FontFallback
        {
            FontFamily = new FontFamily(fontFamilyName)
        });
    }
}
