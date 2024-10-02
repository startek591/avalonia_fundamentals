using Avalonia.Data.Converters;
using Avalonia.Media;

namespace ValueConversionSample.Converter
{
    public static class FuncValueConverters
    {
        public static FuncValueConverter<string?, Brush?> StringToBrushConverter { get; } = new FuncValueConverter<string?, Brush?>(s =>
        {
            Color color;

            if (Color.TryParse(s, out color) || Color.TryParse($"#{s}", out color))
            {
                return new SolidColorBrush(color);
            }

            return null;
        });
    }
}