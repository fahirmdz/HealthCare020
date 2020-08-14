using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Models;
using System;

namespace Healthcare020.Mobile.ViewModels
{
    public class LicniPodaciViewModel : BaseViewModel
    {
        private LicniPodaciDto LicniPodaci;

        public void Init()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }

            LicniPodaci = Auth.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci;
            if (LicniPodaci == null)
            {
                NotificationService.Instance.Error(AppResources.ErrorWhenLoadingResourceMessage);
                return;
            }

            ImePrezime = LicniPodaci.ImePrezime ?? AppResources.NotApplicable;
            DatumRodjenja = LicniPodaci.DatumRodjenja;
            JMBG = LicniPodaci.JMBG ?? AppResources.NotApplicable;
            Adresa = LicniPodaci.Adresa ?? AppResources.NotApplicable;
            BrojTelefona = LicniPodaci.BrojTelefona ?? AppResources.NotApplicable;
            EmailAdresa = LicniPodaci.EmailAddress ?? AppResources.NotApplicable;
            Pol = LicniPodaci.Pol.ToString();
        }

        #region Properties

        private string _imePrezime;

        public string ImePrezime
        {
            get => _imePrezime;
            set => SetProperty(ref _imePrezime, value);
        }

        private DateTime _datumRodjenja;

        public DateTime DatumRodjenja
        {
            get => _datumRodjenja;
            set => SetProperty(ref _datumRodjenja, value);
        }

        private string _jmbg;

        public string JMBG
        {
            get => _jmbg;
            set => SetProperty(ref _jmbg, value);
        }

        private string _adresa;

        public string Adresa
        {
            get => _adresa;
            set => SetProperty(ref _adresa, value);
        }

        private string _brojTelefona;

        public string BrojTelefona
        {
            get => _brojTelefona;
            set => SetProperty(ref _brojTelefona, value);
        }

        private string _pol;

        public string Pol
        {
            get => _pol;
            set => SetProperty(ref _pol, value);
        }

        private string _emailAdresa;

        public string EmailAdresa
        {
            get => _emailAdresa;
            set => SetProperty(ref _emailAdresa, value);
        }

        #endregion Properties
    }
}