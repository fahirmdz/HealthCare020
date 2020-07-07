using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
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


        public SettingsPage()
        {
            _apiService = new APIService(Routes.PacijentiRoute);
            InitializeComponent();
            BindingContext = SettingsVM = new SettingsViewModel();
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

                ProfilePic.Source = ImageSource.FromStream(()
                    => 
                    new MemoryStream(Pacijent.ZdravstvenaKnjizica.LicniPodaci.ProfilePicture.Any() ?
                        Pacijent.ZdravstvenaKnjizica.LicniPodaci.ProfilePicture 
                        : AppResources.user));
            }
        }
    }
}