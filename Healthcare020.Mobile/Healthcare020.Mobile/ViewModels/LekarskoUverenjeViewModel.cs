using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare020.Mobile.ViewModels
{
    public class LekarskoUverenjeViewModel : BaseViewModel
    {
        private readonly IAPIService _apiService;
        private LekarskoUverenjeDtoEL LekarskoUverenje;
        private int? UputnicaId;

        public LekarskoUverenjeViewModel()
        {
            _apiService = new APIService();
        }

        #region Methods

        public async Task Init(int lekarskoUverenjeId)
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }

            _apiService.ChangeRoute(Routes.LekarskoUverenjeRoute);
            var getLekarskoUverenjeResult =
                await _apiService.GetById<LekarskoUverenjeDtoEL>(lekarskoUverenjeId, eagerLoaded: true);
            if (!getLekarskoUverenjeResult.Succeeded || !getLekarskoUverenjeResult.HasData)
            {
                NotificationService.Instance.Error(AppResources.ErrorWhenLoadingResourceMessage);
                return;
            }

            LekarskoUverenje = getLekarskoUverenjeResult.Data;

            _apiService.ChangeRoute(Routes.UputnicaRoute);
            var getUputnicaResult = await _apiService.Get<UputnicaDtoEL>(new UputnicaResourceParameters
            {
                EagerLoaded = true,
                UputioDoktorId = LekarskoUverenje.Pregled.DoktorId,
                Datum = LekarskoUverenje.Pregled.DatumPregleda
            });

            UputnicaId = getUputnicaResult.Data?.FirstOrDefault()?.Id;
            UputnicaFlag = UputnicaId.HasValue;

            Id = LekarskoUverenje.Id;
            ZdravstvenoStanje = LekarskoUverenje.ZdravstvenoStanje.Opis;
            OpisStanja = LekarskoUverenje.OpisStanja;
        }

        #endregion Methods

        #region Commands



        #endregion

        #region Properties

        private int _id;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _zdravstvenoStanje;

        public string ZdravstvenoStanje
        {
            get => _zdravstvenoStanje;
            set => SetProperty(ref _zdravstvenoStanje, value);
        }

        private string _opisStanja;
        public string OpisStanja
        {
            get => _opisStanja;
            set => SetProperty(ref _opisStanja, value);
        }

        private bool _uputnicaFlag;
        public bool UputnicaFlag
        {
            get => _uputnicaFlag;
            set => SetProperty(ref _uputnicaFlag, value);
        }

        #endregion Properties
    }
}