using Xamarin.Forms;

namespace Healthcare020.Mobile.Controls
{
    public class CustomTabbedPage:TabbedPage
    {
        public Color SelectedIconColor
        {
            get => (Color)GetValue(SelectedIconColorProperty);
            set => SetValue(SelectedIconColorProperty, value);
        }
 
        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create(
            nameof(SelectedItemProperty),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);
 
        public Color UnselectedIconColor
        {
            get => (Color)GetValue(UnelectedIconColorProperty);
            set => SetValue(UnelectedIconColorProperty, value);
        }
 
        public static readonly BindableProperty UnelectedIconColorProperty = BindableProperty.Create(
            nameof(UnselectedIconColor),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);
 
        public Color SelectedTextColor
        {
            get => (Color)GetValue(SelectedTextColorProperty);
            set => SetValue(SelectedTextColorProperty, value);
        }
 
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(
            nameof(SelectedTextColor),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);
 
        public Color UnselectedTextColor
        {
            get => (Color)GetValue(UnselectedTextColorProperty);
            set => SetValue(UnselectedTextColorProperty, value);
        }
 
        public static readonly BindableProperty UnselectedTextColorProperty = BindableProperty.Create(
            nameof(UnselectedTextColor),
            typeof(Color),
            typeof(CustomTabbedPage),
            Color.White);
    }
}