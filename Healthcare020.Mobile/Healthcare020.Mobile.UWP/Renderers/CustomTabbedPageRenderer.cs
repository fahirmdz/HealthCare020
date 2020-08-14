using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Healthcare020.Mobile.UWP.Renderers;
using Healthcare020.Mobile.Views;
using Xamarin.Forms.Platform.UWP;
using Image = Windows.UI.Xaml.Controls.Image;

[assembly: ExportRenderer(typeof(PacijentDasbhboardTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace Healthcare020.Mobile.UWP.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private Xamarin.Forms.Page _prevPage;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            Control.Tapped += Control_Tapped;
            _prevPage = Control.SelectedItem as Xamarin.Forms.Page;
        }

        private async void Control_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            // replace 'TabbedHomePage' with whatever your page type is with the tabs
            if (this.Element == null)
                return;

            switch (e.OriginalSource)
            {
                case Image image when image.Parent is StackPanel sp:
                {
                    var tb = sp.Children.FirstOrDefault(c => c is TextBlock) as TextBlock;

                    await HandleRetab(tb);
                    break;
                }
                case TextBlock tb:
                {
                    await HandleRetab(tb);
                    break;
                }
                default:
                    break;
            }

            async Task HandleRetab(TextBlock tb)
            {
                if (tb == null)
                    return;

                var newPage = tb.DataContext as Xamarin.Forms.Page;
                if (newPage == _prevPage &&
                    tb.Name == "TabbedPageHeaderTextBlock")
                {
                    // do your thing here, a tab retap happened, like:
                    if (newPage != null)
                        await newPage.Navigation.PopToRootAsync();
                }

                _prevPage = newPage;
            }
        }
    }
}