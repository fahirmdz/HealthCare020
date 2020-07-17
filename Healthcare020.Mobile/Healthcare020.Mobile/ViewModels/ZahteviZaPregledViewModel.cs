using System;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.Models;
using HealthCare020.Core.ResourceParameters;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class ZahteviZaPregledViewModel : BaseViewModel
    {
        private IAPIService _apiService;

        public ZahteviZaPregledViewModel()
        {
            ZahteviZaPregled = new ObservableCollection<ZahtevZaPregledDtoEL>();
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            await Auth.AuthenticateWithPassword("pacijent", "testtest");
            _apiService = new APIService();

            _apiService.ChangeRoute(Routes.ZahteviZaPregledRoute);
            var result = await _apiService.Get<ZahtevZaPregledDtoEL>(new ZahtevZaPregledResourceParameters
            { EagerLoaded = true });

            if (result.Succeeded)
            {
                if (result.HasData)
                    ZahteviZaPregled = result.Data.ToObservableCollection();
            }
            else
            {
                NotificationService.Instance.Error("Greška pri učitavanju");
            }
        }

        #region Properties

        private ObservableCollection<ZahtevZaPregledDtoEL> _zahteviZaPregled;

        public ObservableCollection<ZahtevZaPregledDtoEL> ZahteviZaPregled
        {
            get=>_zahteviZaPregled;
            set => SetProperty(ref _zahteviZaPregled, value.OrderByDescending(x=>x.DatumVreme).ToObservableCollection());
        }

        #endregion Properties

        #region Comamnds

        public ICommand InitCommand { get; set; }

        #endregion Comamnds
    }
}