using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage
    {
        public BaseViewModel BaseVM { get; set; }

        public SplashScreenPage()
        {
            InitializeComponent();
            BindingContext = BaseVM = new BaseViewModel
            {
                LoadingMessage = AppResources.LoggingInLoadingMessage
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Animation displaying
            await Task.Delay(4000);

            if (await SecureStorage.GetAsync(PreferencesKeys.HasSavedLoginCredentials) is { } val && val == true.ToString())
            {
                if (await Auth.AuthenticateWithSavedCredentials())
                    Application.Current.MainPage = new PacijentDasbhboardTabbedPage();
            }
            else
                Application.Current.MainPage = new WelcomePage();
        }
    }
}