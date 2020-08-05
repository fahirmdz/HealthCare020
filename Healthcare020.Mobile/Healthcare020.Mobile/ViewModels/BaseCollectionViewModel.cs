using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Models;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ResourceParameters;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class BaseCollectionViewModel : BaseViewModel
    {
        protected IAPIService _apiService;
        protected string APIRouteToCollection;
        public BaseResourceParameters ResourceParameters { get; protected set; }
        public int TotalPages { get; protected set; }

        public BaseCollectionViewModel()
        {
            ResourceParameters = new BaseResourceParameters
                {PageSize = ResourceKeys.RowCountZahteviZaPregled.AsResourceType<int>()};

            //Commands init
            NextPageCommand = new Command(NextPage);
            PrevPageCommand = new Command(PrevPage);
            InitCommand = new Command(async () => await Init());
            RefreshDataCommand = new Command(async () => await LoadData());
            SearchCommand = new Command(async () => await Search());
            DataAvailable = true;
        }
        public async Task Init()
        {
            await LoadData();
        }

        #region Properties

        protected string _searchString;

        public string SearchString
        {
            get => _searchString;
            set => SetProperty(ref _searchString, value);
        }

        protected bool _dataAvailable;

        public bool DataAvailable
        {
            get => _dataAvailable;
            set => SetProperty(ref _dataAvailable, value);
        }

        protected ObservableCollection<CollectionViewItem> _mainCollection;

        public ObservableCollection<CollectionViewItem> MainCollection
        {
            get => _mainCollection;
            set => SetProperty(ref _mainCollection, value);
        }

        protected bool _prevNavigationButtonEnabled;

        public bool PrevNavigationButtonEnabled
        {
            get => _prevNavigationButtonEnabled;
            set => SetProperty(ref _prevNavigationButtonEnabled, value);
        }

        protected bool _nextNavigationButtonEnabled;

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

        protected virtual async Task Search()
        {
            return;
        }

        protected async void NextPage()
        {
            if (ResourceParameters.PageNumber == TotalPages)
                return;

            ResourceParameters.PageNumber++;
            await LoadData();
        }

        protected async void PrevPage()
        {
            if (ResourceParameters.PageNumber == 1)
                return;

            ResourceParameters.PageNumber--;
            await LoadData();
        }

        protected virtual ObservableCollection<CollectionViewItem> CollectionViewItemConvertor(ObservableCollection<dynamic> collection)
        {
            return new ObservableCollection<CollectionViewItem>();
        }

        protected async Task LoadData()
        {
            await Auth.AuthenticateWithPassword("pacijent", "testtest");

            IsBusy = true;
            _apiService = new APIService();
            _apiService.ChangeRoute(APIRouteToCollection);
            var result = await _apiService.Get<dynamic>(ResourceParameters);

            if (result.Succeeded)
            {
                if (result.HasData)
                {
                    MainCollection = CollectionViewItemConvertor(result.Data.ToObservableCollection());
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