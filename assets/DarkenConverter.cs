using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace SetApp
{
    public class DarkenConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is IBrush brush)
            {
                if (brush is ISolidColorBrush solidBrush)
                {
                    var color = solidBrush.Color;
                    return new SolidColorBrush(Color.FromArgb(
                        color.A,
                        (byte)Math.Max(0, color.R - 30),
                        (byte)Math.Max(0, color.G - 30),
                        (byte)Math.Max(0, color.B - 30)));
                }
            }
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 