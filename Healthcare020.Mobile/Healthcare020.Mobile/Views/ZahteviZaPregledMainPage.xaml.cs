using Healthcare020.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZahteviZaPregledMainPage : ContentPage
    {
        public ZahteviZaPregledMainPage()
        {
            Title = AppResources.ZahteviTabTitle;
            InitializeComponent();
        }
    }
}