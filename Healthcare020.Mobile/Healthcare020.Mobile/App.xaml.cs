using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using HealthCare020.Core.Extensions;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Healthcare020.Mobile
{
    public enum DeviceScreenSize { Small, Medium, Large }

    public partial class App : Application
    {
        private const int smallWidthResoulution = 1100;
        private const int smallHeightResolution = 2000;

        private const int mediumWidthResoultion = 1450;
        private const int mediumHeightResolution = 3100;

        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static DeviceScreenSize DeviceScreenSize;

        public App()
        {
            InitializeComponent();
            LoadStyles();

            DependencyService.Register<MockDataStore>();
            Device.SetFlags(new[] { "Shapes_Experimental", "MediaElement_Experimental" });

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
        private void LoadStyles()
        {
            ResourceDictionary DictionaryToAdd;
            DeviceScreenSize = DetermineScreenSize();

            if (DeviceScreenSize == DeviceScreenSize.Medium)
                return;

            switch (DeviceScreenSize)
            {
                case DeviceScreenSize.Small:
                    DictionaryToAdd = SmallDevicesStyle.SharedInstance;
                    break;

                case DeviceScreenSize.Large:
                    DictionaryToAdd = LargeDevicesStyle.SharedInstance;
                    break;

                default:
                    return;
            }

            var diffElements = MainResourceDictionary.Where(x => !DictionaryToAdd.ContainsKey(x.Key));
            var ElementsFromMainResourceDictionaryToAdd = new ResourceDictionary();
            foreach (var x in diffElements)
            {
                ElementsFromMainResourceDictionaryToAdd.Add(x.Key, x.Value);
            }

            MainResourceDictionary.Clear();
            MainResourceDictionary.Add(DictionaryToAdd);
            MainResourceDictionary.MergedDictionaries.Add(ElementsFromMainResourceDictionaryToAdd);
        }

        public static DeviceScreenSize DetermineScreenSize()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            if (width <= smallWidthResoulution && height <= smallHeightResolution)
                return DeviceScreenSize.Small;
            if (width >= smallWidthResoulution && width <= mediumWidthResoultion && height >= smallHeightResolution &&
                height <= mediumHeightResolution)
                return DeviceScreenSize.Medium;
            return DeviceScreenSize.Large;
        }
    }
}