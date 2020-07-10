using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Healthcare020.Mobile
{
    public partial class App : Application
    {
        const int smallWightResolution = 1100;
        const int smallHeightResolution = 2000;
        public static int ScreenHeight {get; set;}
        public static int ScreenWidth {get; set;}
        public App()
        {
            InitializeComponent();
            LoadStyles();

            DependencyService.Register<MockDataStore>();
            Device.SetFlags(new []{"Shapes_Experimental","MediaElement_Experimental"});

            MainPage = new WelcomePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        //Determine which styles to apply, based on current device screen size
        void LoadStyles()
        {
            if (IsASmallDevice())
            {
                MainResourceDictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                MainResourceDictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }
    }
}