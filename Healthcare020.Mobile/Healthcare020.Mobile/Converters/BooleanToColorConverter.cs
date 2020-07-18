using System;
using System.Globalization;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Converters
{
    public class BooleanToColorConverter:IValueConverter
    {
        public Color TrueColor { set; get; }

        public Color FalseColor { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Color) value == TrueColor;
        }
    }
}