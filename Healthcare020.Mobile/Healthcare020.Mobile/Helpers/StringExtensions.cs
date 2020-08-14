using System;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Helpers
{
    public static class StringExtensions
    {
        public static T AsResourceType<T>(this string resourceKey)
        {
            if (string.IsNullOrWhiteSpace(resourceKey))
                return default;
            try
            {
                return (T) Application.Current.Resources[resourceKey];
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}