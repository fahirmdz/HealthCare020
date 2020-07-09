using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using Xamarin.Forms;

namespace Healthcare020.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new PacijentDasbhboardTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}