using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;

namespace Healthcare020.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new WelcomePage();
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
