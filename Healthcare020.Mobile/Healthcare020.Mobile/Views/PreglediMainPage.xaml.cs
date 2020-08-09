using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using System;
using Healthcare020.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreglediMainPage : ContentPage
    {
        private NavigationPage NavigationPageParent;

        public PreglediMainPage()
        {
            Title = AppResources.PreglediTabTitle;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await Auth.AuthenticateWithPassword("pacijent", "testtest");

            base.OnAppearing();
            NavigationPageParent = (NavigationPage)Parent;
        }

        private async void ZakazaniPregledi_OnTapped(object sender, EventArgs e)
        {
            await ZakazaniPreglediButton.ScaleEffect(1.1);
            await NavigationPageParent.PushAsync(new PreglediPage(OnlyZakazani: true), true);
        }

        private async void SviPregledi_OnTapped(object sender, EventArgs e)
        {
            await SviPreglediButton.ScaleEffect(1.1);
            await NavigationPageParent.PushAsync(new PreglediPage(), true);
        }

        private async void NoviPregled_OnTapped(object sender, EventArgs e)
        {
            await ZakazivanjePregledaButton.ScaleEffect(1.1);
            await NavigationPageParent.PushAsync(new NoviZahtevZaPregledPage(), true);
        }
    }
}