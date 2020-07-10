using Healthcare020.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LekarskaUverenjaMainPage : ContentPage
    {
        public LekarskaUverenjaMainPage()
        {
            Title = AppResources.LekarskaUverenjaPageTitle;
            InitializeComponent();
        }
    }
}