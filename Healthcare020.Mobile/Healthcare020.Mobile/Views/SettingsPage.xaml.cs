using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System;
using System.Linq;
using Healthcare020.Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel SettingsVM { get; set; }
        private PacijentDtoEL Pacijent;
        private readonly APIService _apiService;
        private readonly OnPlatform<string> FontAwesomeRegular;

        public SettingsPage()
        {
            _apiService = new APIService(Routes.PacijentiRoute);
            InitializeComponent();
            BindingContext = SettingsVM = ViewModelLocator.SettingsViewModel;
            FontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            LogoutBtn.ImageSource = new FontImageSource
            {
                FontFamily = FontAwesomeRegular,
                Glyph = IconFont.SignOutAlt,
                Color = Color.WhiteSmoke,
                Size = 30
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var pacijentResult =
                await _apiService.Get<PacijentDtoEL>(new PacijentResourceParameters
                {
                    EagerLoaded = true,
                    KorisnickiNalogId = Auth.KorisnickiNalog.Id
                });

            if (pacijentResult.Succeeded && (pacijentResult.Data?.Any() ?? false))
            {
                Pacijent = pacijentResult.Data.First();
            }
        }

        private void LogoutBtn_OnClicked(object sender, EventArgs e)
        {
            SettingsVM.LogoutCommand.Execute(sender);
        }
    }
}