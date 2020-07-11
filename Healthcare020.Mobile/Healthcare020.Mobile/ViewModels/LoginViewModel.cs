using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class LoginViewModel : BaseValidationViewModel
    {
        public LoginViewModel()
        {
        }

        #region Properties

        private string _username;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        public string Username
        {
            get => _username;
            set
            {
                if (ValidateProperty(nameof(Username), value))
                {
                    SetProperty(ref _username, value);
                }
            }
        }

        private string _password;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        public string Password
        {
            get => _password;
            set
            {
                if (ValidateProperty(nameof(Password), value))
                {
                    SetProperty(ref _password, value);
                }
            }
        }

        private bool _rememberMe;

        public bool RememberMe
        {
            get => _rememberMe;
            set => SetProperty(ref _rememberMe, value);
        }

        #endregion Properties

        #region Commands

        public ICommand LoginCommand => new Command(async () =>
        {
            if (!IsValidModel)
                return;

            IsBusy = true;
            if (string.IsNullOrWhiteSpace(Username))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return;
            }

            if (await Auth.AuthenticateWithPassword(Username, Password, RememberMe))
            {
                Application.Current.MainPage = new PacijentDasbhboardTabbedPage();
            }

            IsBusy = false;
        });

        public ICommand RegisterNavigationCommand => new Command(() =>
        {
            Application.Current.MainPage = new RegisterPage();
        });

        #endregion Commands
    }
}