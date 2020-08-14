using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views.Dialogs;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class PregledViewModel : BaseViewModel
    {
        private readonly IAPIService _apiService;
        private PregledDtoEL Pregled;
        private int? LekarskoUverenjeId;

        public PregledViewModel()
        {
            _apiService = new APIService();
        }

        #region Methods

        public async Task Init(int pregledId)
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }

            _apiService.ChangeRoute(Routes.PreglediRoute);
            var getPregledResult =
                await _apiService.GetById<PregledDtoEL>(pregledId, eagerLoaded: true);

            if (!getPregledResult.Succeeded || !getPregledResult.HasData || getPregledResult.Data == null)
            {
                NotificationService.Instance.Error(AppResources.ErrorWhenLoadingResourceMessage);
                return;
            }
            Pregled = getPregledResult.Data;

            if (Pregled.IsOdradjen)
            {
                _apiService.ChangeRoute(Routes.LekarskoUverenjeRoute);
                var getLekarskoUverenjeResult = await _apiService.Get<LekarskoUverenjeDtoLL>(
                    new LekarskoUverenjeResourceParameters
                    {
                        PregledId = pregledId
                    });

                if (getLekarskoUverenjeResult.Succeeded && getLekarskoUverenjeResult.HasData)
                {
                    var lekarskoUverenje = getLekarskoUverenjeResult.Data.FirstOrDefault();
                    if (lekarskoUverenje != null)
                    {
                        LekarskoUverenjeId = lekarskoUverenje.Id;
                    }
                }
            }

            Id = pregledId;
            Doktor = Pregled.Doktor;
            DateTime = Pregled.DatumPregleda;
            IsOdradjen = Pregled.IsOdradjen;
        }

        #endregion Methods

        #region Commands

        public ICommand LekarskoUverenjeCommand => new Command(async () =>
          {
              if (LekarskoUverenjeId.HasValue)
              {
                  await Application.Current.MainPage.Navigation.PushPopupAsync(
                      new LekarskoUverenjeDialogPage(LekarskoUverenjeId.Value));
              }
          });

        #endregion Commands

        #region Properties

        public int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string _doktor;

        public string Doktor
        {
            get => _doktor;
            set => SetProperty(ref _doktor, value);
        }

        public DateTime _dateTime;

        public DateTime DateTime
        {
            get => _dateTime;
            set => SetProperty(ref _dateTime, value);
        }

        public bool _isOdradjen;

        public bool IsOdradjen
        {
            get => _isOdradjen;
            set => SetProperty(ref _isOdradjen, value);
        }

        #endregion Properties
    }
}