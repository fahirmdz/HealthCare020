using System.Linq;
using Xamarin.Forms;

namespace Healthcare020.Mobile.Helpers
{
    public static class ResourceExtensions
    {
        /// <summary>
        /// Change value of dynamic style resource setter
        /// </summary>
        public static void ChangeStyleSetterValue(this string resourceKey, string propertyName, object value)
        {
            if (Application.Current.Resources[resourceKey] is { } resource && resource as Style is { } style)
            {
                if (style.Setters.FirstOrDefault(x => x.Property.PropertyName.StartsWith(propertyName)) is { } setter)
                    setter.Value = value;
            }
        }
    }
}