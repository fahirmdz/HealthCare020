using Syncfusion.XForms.Themes;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class PacijentDashboardViewModel : BaseViewModel
    {
        public PacijentDashboardViewModel()
        {
            ChangeCountryCommand = new Command(async (args) => await ExecuteChangeCountryCommand());
            RefreshGlobalCommand = new Command(async () => await ExecuteRefreshGlobalCommand());
            RefreshCountryCommand = new Command(async () => await ExecuteRefreshCountryCommand());
            NavigateToSearchCountryCommand = new Command(async () => await ExecuteNavigateToSearchCountryCommand());
            NavigateToReadMorePageCommand = new Command(async () => await ExecuteNavigateToReadMorePageCommand());
            ShowChangeLanguagePagePopUpCommand = new Command(async () => await ExecuteShowChangeLanguagePagePopUpCommand());
            ChangeThemeAppCommand = new Command(ExecuteChangeThemeAppCommand);
            GetAppVersion();
            InitData();
        }

        public Command ChangeCountryCommand { get; }
        public Command RefreshGlobalCommand { get; }
        public Command RefreshCountryCommand { get; }
        public Command NavigateToSearchCountryCommand { get; }
        public Command NavigateToReadMorePageCommand { get; }
        public Command ShowChangeLanguagePagePopUpCommand { get; }
        public Command ChangeThemeAppCommand { get; }

        public string CountryISO2 { get; set; }

        private string _lastUpdateHeader;

        public string LastUpdateHeader
        {
            get => _lastUpdateHeader;
            set => SetProperty(ref _lastUpdateHeader, value);
        }

        private string _globalUpdateHeader;

        public string GlobalUpdateHeader
        {
            get => _globalUpdateHeader;
            set => SetProperty(ref _globalUpdateHeader, value);
        }

        private string _globalConfirmed;

        public string GlobalConfirmed
        {
            get => _globalConfirmed;
            set => SetProperty(ref _globalConfirmed, value);
        }

        private string _globalRecovered;

        public string GlobalRecovered
        {
            get => _globalRecovered;
            set => SetProperty(ref _globalRecovered, value);
        }

        private string _globalDeaths;

        public string GlobalDeaths
        {
            get => _globalDeaths;
            set => SetProperty(ref _globalDeaths, value);
        }

        private string _iconArrow;

        public string IconArrow
        {
            get => _iconArrow;
            set => SetProperty(ref _iconArrow, value);
        }

        private string _flagCode;

        public string FlagCode
        {
            get => _flagCode;
            set => SetProperty(ref _flagCode, value);
        }

        private string _lastUpdateSubtitleCountry;

        public string LastUpdateSubtitleCountry
        {
            get => _lastUpdateSubtitleCountry;
            set => SetProperty(ref _lastUpdateSubtitleCountry, value);
        }

        private string _countryConfirmed;

        public string CountryConfirmed
        {
            get => _countryConfirmed;
            set => SetProperty(ref _countryConfirmed, value);
        }

        private string _countryRecovered;

        public string CountryRecovered
        {
            get => _countryRecovered;
            set => SetProperty(ref _countryRecovered, value);
        }

        private string _countryDeaths;

        public string CountryDeaths
        {
            get => _countryDeaths;
            set => SetProperty(ref _countryDeaths, value);
        }

        private string _countryFlag;

        public string CountryFlag
        {
            get => _countryFlag;
            set => SetProperty(ref _countryFlag, value);
        }

        private string _countryNameSelected;

        public string CountryNameSelected
        {
            get => _countryNameSelected;
            set => SetProperty(ref _countryNameSelected, value);
        }

        private string _appVersion;

        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }

        private string _confirmedHeader;

        public string ConfirmedHeader
        {
            get => _confirmedHeader;
            set => SetProperty(ref _confirmedHeader, value);
        }

        private string _recoveredHeader;

        public string RecoveredHeader
        {
            get => _recoveredHeader;
            set => SetProperty(ref _recoveredHeader, value);
        }

        private string _deathsHeader;

        public string DeathsHeader
        {
            get => _deathsHeader;
            set => SetProperty(ref _deathsHeader, value);
        }

        private string _refreshHeader;

        public string RefreshHeader
        {
            get => _refreshHeader;
            set => SetProperty(ref _refreshHeader, value);
        }

        private string _learnAboutCovid;

        public string LearnAboutCovid
        {
            get => _learnAboutCovid;
            set => SetProperty(ref _learnAboutCovid, value);
        }

        private string _readMoreCovid;

        public string ReadMoreCovid
        {
            get => _readMoreCovid;
            set => SetProperty(ref _readMoreCovid, value);
        }

        private string _hashTagCovid;

        public string HashTagCovid
        {
            get => _hashTagCovid;
            set => SetProperty(ref _hashTagCovid, value);
        }

        public bool AppDarkTheme
        {
            get => Preferences.Get("appDarkTheme", false);
            set => Preferences.Set("appDarkTheme", value);
        }


        public async Task GetGlobalTotals(bool isBusyCountry = false)
        {
            IsBusy = true;

            try
            {
                if (false)
                {
                   
                }
                else
                {
                    
                }
            }
            catch { }
            finally
            {
                IsBusy = false;
            }
        }

       

        private async Task ExecuteChangeCountryCommand()
        {
        }

        private async Task ExecuteRefreshGlobalCommand()
        {
            
        }

        private async Task ExecuteRefreshCountryCommand()
        {
           
        }

        private async Task ExecuteNavigateToSearchCountryCommand()
        {
           
        }

        private async Task ExecuteNavigateToReadMorePageCommand()
        {
           
        }

        private void InitData()
        {
            Title = "Pacijent dashboard";
            GlobalUpdateHeader = "Global update header";
            RefreshHeader = "RefreshHeader";
            ConfirmedHeader = "ConfirmedHeader";
            RecoveredHeader = "RecoveredHeader";
            DeathsHeader = "DeathsHeader";
            CountryISO2 = "BA";
            LastUpdateHeader = "------------------------------";
            GlobalConfirmed = "-";
            GlobalRecovered = "-";
            GlobalDeaths = "-";
            LastUpdateSubtitleCountry = "------------------------------";
            CountryConfirmed = "-";
            CountryRecovered = "-";
            CountryDeaths = "-";
            LearnAboutCovid = "LearnAboutCovid";
            ReadMoreCovid = "ReadMoreCovid";
            HashTagCovid = "HashTagCovid";
            SetDarkTheme(AppDarkTheme);
        }

        private void GetAppVersion()
        {
            AppVersion = $"v{VersionTracking.CurrentVersion}";
        }

        private async Task ExecuteShowChangeLanguagePagePopUpCommand()
        {
            //if (IsTouched)
            //    return;

            //IsTouched = true;
            //await Navigation.PushPopupAsync(new ChangeLanguagePage());
            //IsTouched = false;
        }

        public void SubscribeChangeLanguage()
        {
            //MessagingCenter.Subscribe<ChangeLanguagePageViewModel>(this, "changeLanguage", (s) =>
            //{
            //    ChangeLanguageApp();
            //});

            //MessagingCenter.Subscribe<ChangeLanguagePageViewModel, bool>(this, "changeAppTheme", (s, param) =>
            //{
            //    AppDarkTheme = param;
            //    SetDarkTheme(param);
            //});

            //MessagingCenter.Subscribe<SearchCountryViewModel, string>(this, "countrySelected", (s, param) =>
            //{
            //    GetCountryByISO2(param);
            //});
        }

        public void UnsubscribeEvents()
        {
            //MessagingCenter.Unsubscribe<ChangeLanguagePageViewModel>(this, "changeLanguage");
            //MessagingCenter.Unsubscribe<ChangeLanguagePageViewModel>(this, "changeAppTheme");
            //MessagingCenter.Unsubscribe<SearchCountryViewModel>(this, "countrySelected");
        }

        private void ExecuteChangeThemeAppCommand()
        {
            SetDarkTheme(true);
        }

        private void SetDarkTheme(bool darkTheme)
        {
            
        }
    }
}