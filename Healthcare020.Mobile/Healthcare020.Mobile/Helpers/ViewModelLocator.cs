﻿using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.ViewModels;

namespace Healthcare020.Mobile.Helpers
{
    public static class ViewModelLocator
    {
        private static readonly ILocator Locator = Bootstrap.GetLocator();

        static ViewModelLocator()
        {
            Locator.Register<WelcomeViewModel>();
            Locator.Register<LoginViewModel>();
            Locator.Register<SettingsViewModel>();
            Locator.Register<PregledViewModel>();
            Locator.Register<LekarskoUverenjeViewModel>();
            Locator.Register<LekarskaUverenjaViewModel>();
            Locator.Register<ChangePasswordViewModel>();
            Locator.Register<NoviZahtevZaPregledViewModel>();
            Locator.Register<RegisterViewModel>();
            Locator.Register<PosetaViewModel>();
            Locator.Register<PreglediViewModel>();
            Locator.Register<PasswordCheckViewModel>();
            Locator.Register<EditProfileViewModel>();
            Locator.Register<LicniPodaciViewModel>();
        }

        public static WelcomeViewModel WelcomeViewModel => Locator.GetInstance<WelcomeViewModel>();
        public static LoginViewModel LoginViewModel => Locator.GetInstance<LoginViewModel>();
        public static SettingsViewModel SettingsViewModel => Locator.GetInstance<SettingsViewModel>();
        public static RegisterViewModel RegisterViewModel => Locator.GetInstance<RegisterViewModel>();
        public static PosetaViewModel PosetaViewModel => Locator.GetInstance<PosetaViewModel>();
        public static PreglediViewModel PreglediViewModel => Locator.GetInstance<PreglediViewModel>();
        public static PregledViewModel PregledViewModel => Locator.GetInstance<PregledViewModel>();
        public static LekarskoUverenjeViewModel LekarskoUverenjeViewModel => Locator.GetInstance<LekarskoUverenjeViewModel>();
        public static LekarskaUverenjaViewModel LekarskaUverenjaViewModel => Locator.GetInstance<LekarskaUverenjaViewModel>();
        public static ChangePasswordViewModel ChangePasswordViewModel => Locator.GetInstance<ChangePasswordViewModel>();
        public static NoviZahtevZaPregledViewModel NoviZahtevZaPregledViewModel => Locator.GetInstance<NoviZahtevZaPregledViewModel>();
        public static PasswordCheckViewModel PasswordCheckViewModel => Locator.GetInstance<PasswordCheckViewModel>();
        public static EditProfileViewModel EditProfileViewModel => Locator.GetInstance<EditProfileViewModel>();
        public static LicniPodaciViewModel LicniPodaciViewModel => Locator.GetInstance<LicniPodaciViewModel>();
    }
}