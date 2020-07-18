using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using System;
using Xamarin.Forms;
using BindingMode = Xamarin.Forms.BindingMode;
using Frame = Xamarin.Forms.Frame;
using Image = Xamarin.Forms.Image;
using Label = Xamarin.Forms.Label;

namespace Healthcare020.Mobile.Controls
{
    [ContentProperty("Message")]
    public class NoDataFrame : Frame
    {
        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public static void MessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create("Message", typeof(string), typeof(NoDataFrame), "Trenutno nema dostupnih podataka", BindingMode.Default, null, MessageChanged);

        public NoDataFrame() : base()
        {
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            this.BackgroundColor=Color.Transparent;
            try
            {
                var stackToAdd = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = Color.Transparent
                };
                stackToAdd.Children.Add(new Image
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Source = new FontImageSource
                    {
                        FontFamily = ResourceKeys.FontAwesomeRegularFamily.AsResourceType<OnPlatform<string>>(),
                        Color = ResourceKeys.LightNavyBlueColor.AsResourceType<Color>(),
                        Glyph = IconFont.Database,
                        Size = ResourceKeys.IconSizeLarge.AsResourceType<OnPlatform<double>>()
                    }
                });
                var lblToAdd = new Label
                {
                    Margin = new Thickness(0,15,0,0),
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = ResourceKeys.FontSizeMedium.AsResourceType<OnPlatform<double>>(),
                    FontAttributes = FontAttributes.Bold,
                    Text = Message
                };

                stackToAdd.Children.Add(lblToAdd);

                var lblTapToRefresh = new Label
                {
                    Margin = new Thickness(0, 10, 0, 0),
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = ResourceKeys.FontSizeSmall.AsResourceType<OnPlatform<double>>(),
                    Text = "Tap to refresh",
                    TextColor = Color.Gray
                };
                stackToAdd.Children.Add(lblTapToRefresh);

                this.Content = stackToAdd;
            }
            catch (Exception ex)
            {
                //ignore
            }
        }
    }
}