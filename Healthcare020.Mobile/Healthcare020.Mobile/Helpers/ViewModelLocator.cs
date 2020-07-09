using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.ViewModels;

namespace Healthcare020.Mobile.Helpers
{
    public static class ViewModelLocator
    {
        private static ILocator Locator = Bootstrap.GetLocator();

        static ViewModelLocator()
        {
            Locator.Register<WelcomeViewModel>();
            Locator.Register<LoginViewModel>();
        }

        public static WelcomeViewModel WelcomeViewModel => Locator.GetInstance<WelcomeViewModel>();
        public static LoginViewModel LoginViewModel => Locator.GetInstance<LoginViewModel>();
        public static PacijentDashboardViewModel PacijentDashboardViewModel => Locator.GetInstance<PacijentDashboardViewModel>();
        public static SettingsViewModel SettingsViewModel => Locator.GetInstance<SettingsViewModel>();
    }
}