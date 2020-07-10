using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public RegisterViewModel()
        {

        }

        public ICommand RegisterCommand =>new Command(() =>
        {

        });

        public ICommand CancelRegistrationCommand =>new Command(() =>
        {

        });

        #region Properties

        private string _brojKnjizice;
        public string BrojKnjizice
        {
            get => _brojKnjizice;
            set => SetProperty(ref _brojKnjizice, value);
        }

        private string _ime;
        public string Ime
        {
            get => _ime;
            set => SetProperty(ref _ime, value);
        }

        private string _prezime;
        public string Prezime
        {
            get => _brojKnjizice;
            set => SetProperty(ref _prezime, value);
        }

        private string _username;
        public string Username
        {
            get => _brojKnjizice;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _brojKnjizice;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _brojKnjizice;
            set => SetProperty(ref _confirmPassword, value);
        }

        #endregion
    }
}