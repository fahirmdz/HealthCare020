using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare020.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenPage : ContentPage
    {
        private ActivityIndicator aIndicator;
        public SplashScreenPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            aIndicator = new ActivityIndicator {Color = Color.FromRgb(0, 130, 130), IsRunning = true};

            var loggedInWithSavedCredentials = await Auth.AuthenticateWithSavedCredentials();
            if(loggedInWithSavedCredentials)
            {
                await Application.Current.MainPage.DisplayAlert("Obavestenje",
                    "Logovani uz pomoc sacuvanih kredencijala", "Ok");
            }
            else
                Application.Current.MainPage=new LoginPage();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            aIndicator.IsRunning = false;
        }
    }
}