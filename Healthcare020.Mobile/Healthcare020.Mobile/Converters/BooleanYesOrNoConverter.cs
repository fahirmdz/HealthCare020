using System;
using System.Globalization;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Converters
{
    public class BooleanYesOrNoConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? "DA" : "NE";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string) value == "DA";
        }
    }
}