using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
        }

        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _rememberMe;

        public bool RememberMe
        {
            get => _rememberMe;
            set => SetProperty(ref _rememberMe, value);
        }

        public ICommand LoginCommand => new Command(Login);
        public ICommand RegisterNavigationCommand => new Command(() =>
        {
            Application.Current.MainPage=new RegisterPage();
        });

        private async void Login()
        {
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
        }
    }
}