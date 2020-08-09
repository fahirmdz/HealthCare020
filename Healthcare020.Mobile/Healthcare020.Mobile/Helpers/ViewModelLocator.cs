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
            Locator.Register<SettingsViewModel>();
            Locator.Register<PregledViewModel>();
            Locator.Register<LekarskoUverenjeViewModel>();
            Locator.Register<LekarskaUverenjaViewModel>();
        }

        public static WelcomeViewModel WelcomeViewModel => Locator.GetInstance<WelcomeViewModel>();
        public static LoginViewModel LoginViewModel => Locator.GetInstance<LoginViewModel>();
        public static SettingsViewModel SettingsViewModel => Locator.GetInstance<SettingsViewModel>();
        public static RegisterViewModel RegisterViewModel => Bootstrap.GetContainer().Resolve<RegisterViewModel>();
        public static PosetaViewModel PosetaViewModel => Bootstrap.GetContainer().Resolve<PosetaViewModel>();
        public static PreglediViewModel PreglediViewModel => Bootstrap.GetContainer().Resolve<PreglediViewModel>();
        public static PregledViewModel PregledViewModel => Locator.GetInstance<PregledViewModel>();
        public static LekarskoUverenjeViewModel LekarskoUverenjeViewModel => Locator.GetInstance<LekarskoUverenjeViewModel>();
        public static LekarskaUverenjaViewModel LekarskaUverenjaViewModel => Locator.GetInstance<LekarskaUverenjaViewModel>();

    }
}