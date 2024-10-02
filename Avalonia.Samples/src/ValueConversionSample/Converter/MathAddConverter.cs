using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ValueConversionSample.Converter
{
    public class MathAddConverter : IValueConverter
    {

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (decimal?)value + (decimal?)parameter;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (decimal?)value - (decimal?)parameter;
        }
    }
}