using System.Collections;
using System.Windows.Input;

namespace Healthcare020.Mobile.ViewModels
{
    public class CustomCollectionViewModel : BaseViewModel
    {
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

        private IEnumerable _collectionItems;

        public IEnumerable CollectionItems
        {
            get => _collectionItems;
            set => SetProperty(ref _collectionItems, value);
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
    }
}