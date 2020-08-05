using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZakazaniPreglediPage : ContentPage
    {
        public ZakazaniPreglediViewModel ZakazaniPreglediVM { get; set; }

        public ZakazaniPreglediPage()
        {
            Title = AppResources.ZakazaniPreglediPageTitle;
            InitializeComponent();
            BindingContext = ZakazaniPreglediVM = ViewModelLocator.ZakazaniPreglediViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ZakazaniPreglediVM.Init();
        }
    }
}