﻿using Healthcare020.Mobile.Constants;
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
    public partial class SplashScreenPage : ContentPage
    {
        public BaseViewModel BaseVM { get; set; }

        public SplashScreenPage()
        {
            InitializeComponent();
            BindingContext = BaseVM = new BaseViewModel {
                LoadingMessage = AppResources.LoggingInLoadingMessage
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (await SecureStorage.GetAsync(PreferencesKeys.HasSavedLoginCredentials) is string val && val == true.ToString())
            {
                BaseVM.IsBusy = true;
                var loggedInWithSavedCredentials = await Auth.AuthenticateWithSavedCredentials();
                if (loggedInWithSavedCredentials)
                    Application.Current.MainPage = new PacijentDasbhboardTabbedPage();

                BaseVM.IsBusy = false;
            }
            else
                Application.Current.MainPage = new LoginPage();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}