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
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class ZahteviZaPregledViewModel : BaseViewModel
    {
        private IAPIService _apiService;
        public ZahtevZaPregledResourceParameters ResourceParameters { get; private set; }
        public int TotalPages { get; private set; }

        public ZahteviZaPregledViewModel()
        {
            ZahteviZaPregled = new ObservableCollection<ZahtevZaPregledDtoEL>();
            ResourceParameters = new ZahtevZaPregledResourceParameters { EagerLoaded = true, PageSize = ResourceKeys.RowCountZahteviZaPregled.AsResourceType<int>() };

            //Commands init
            NextPageCommand = new Command(NextPage);
            PrevPageCommand = new Command(PrevPage);
            InitCommand = new Command(async () => await Init());
            RefreshDataCommand = new Command(async ()=>await LoadData());
            SearchCommand=new Command(Search);
        }

        public async Task Init()
        {
            await Auth.AuthenticateWithPassword("pacijent", "testtest");
            _apiService = new APIService();
            await LoadData();
        }

        #region Properties

        private string _searchString;
        public string SearchString
        {
            get => _searchString;
            set => SetProperty(ref _searchString, value);
        }

        private bool _dataAvailable;
        public bool DataAvailable
        {
            get => _dataAvailable;
            set => SetProperty(ref _dataAvailable, value);
        }

        private ObservableCollection<ZahtevZaPregledDtoEL> _zahteviZaPregled;
        public ObservableCollection<ZahtevZaPregledDtoEL> ZahteviZaPregled
        {
            get => _zahteviZaPregled;
            set => SetProperty(ref _zahteviZaPregled, value);
        }

        private bool _prevNavigationButtonEnabled;
        public bool PrevNavigationButtonEnabled
        {
            get => _prevNavigationButtonEnabled;
            set => SetProperty(ref _prevNavigationButtonEnabled, value);
        }

        private bool _nextNavigationButtonEnabled;
        public bool NextNavigationButtonEnabled
        {
            get => _nextNavigationButtonEnabled;
            set => SetProperty(ref _nextNavigationButtonEnabled, value);
        }

        #endregion Properties

        #region Comamnds

        public ICommand InitCommand { get; set; }
        public ICommand RefreshDataCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand NextPageCommand { get; set; }
        public ICommand PrevPageCommand { get; set; }

        #endregion Comamnds

        private async void Search()
        {
            if(SearchString!=ResourceParameters.Napomena)
            {
                ResourceParameters.Napomena = SearchString;
                await LoadData();
            }
        }

        private async void NextPage()
        {
            if (ResourceParameters.PageNumber == TotalPages)
                return;

            ResourceParameters.PageNumber++;
            await LoadData();
        }

        private async void PrevPage()
        {
            if (ResourceParameters.PageNumber == 1)
                return;

            ResourceParameters.PageNumber--;
            await LoadData();
        }

        private async Task LoadData()
        {
            IsBusy = true;
            _apiService.ChangeRoute(Routes.ZahteviZaPregledRoute);
            var result = await _apiService.Get<ZahtevZaPregledDtoEL>(ResourceParameters);

            if (result.Succeeded)
            {
                if (result.HasData)
                {
                    ZahteviZaPregled = result.Data.ToObservableCollection();
                    TotalPages = result.PaginationMetadata.TotalPages;

                    NextNavigationButtonEnabled = ResourceParameters.PageNumber < TotalPages;
                    PrevNavigationButtonEnabled = ResourceParameters.PageNumber > 1;

                    DataAvailable = true;
                }
                else
                {
                    DataAvailable = false;
                }

                IsBusy = false;
            }
            else
            {
                IsBusy = false;
                DataAvailable = false;
                NotificationService.Instance.Error("Greška pri učitavanju");
            }
        }
    }
}