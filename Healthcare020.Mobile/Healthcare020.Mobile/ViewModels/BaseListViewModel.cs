using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Models;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ResourceParameters;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
#pragma warning disable 1998

namespace Healthcare020.Mobile.ViewModels
{
    public class BaseListViewModel : BaseViewModel
    {
        protected IAPIService _apiService;
        protected string APIRouteToCollection;
        public BaseResourceParameters ResourceParameters { get; protected set; }
        public int TotalPages { get; protected set; }

        public BaseListViewModel()
        {
            ResourceParameters = new BaseResourceParameters
            { PageSize = ResourceKeys.RowCountZahteviZaPregled.AsResourceType<int>() };

            //Commands init
            NextPageCommand = new Command(NextPage);
            PrevPageCommand = new Command(PrevPage);
            InitCommand = new Command(async () => await Init());
            RefreshDataCommand = new Command(async () => await LoadData());
            SearchCommand = new Command(async () => await Search());
            CollectionItemTappedCommand = new Command(async () => await CollectionItem_Tapped());
            DataAvailable = true;
        }

        public virtual async Task Init()
        {
            await LoadData();
        }

        protected virtual async Task CollectionItem_Tapped()
        {
        }

        #region Properties

        protected string _searchEntryPlaceholder;
        public string SearchEntryPlaceholder
        {
            get => _searchEntryPlaceholder;
            set => SetProperty(ref _searchEntryPlaceholder, value);
        }

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

        public ICommand InitCommand { get; }
        public ICommand RefreshDataCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        public ICommand CollectionItemTappedCommand { get; }

        #endregion Comamnds

        protected virtual async Task Search()
        {
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