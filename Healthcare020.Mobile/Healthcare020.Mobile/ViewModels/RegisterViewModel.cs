using Healthcare020.Mobile.Resources;
using HealthCare020.Core.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class RegisterViewModel : BaseValidationViewModel
    {
        public RegisterViewModel()
        {
        }

        public ICommand RegisterCommand => new Command(() =>
         {
         });

        public ICommand CancelRegistrationCommand => new Command(() =>
         {
         });

        #region Properties

        private string _brojKnjizice;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [DigitsOnly(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.LettersOnlyError))]
        public string BrojKnjizice
        {
            get => _brojKnjizice;
            set
            {
                if (ValidateProperty(nameof(BrojKnjizice),value))
                {
                    SetProperty(ref _brojKnjizice, value);
                }
            }

        }

        private string _ime;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [LettersOnly(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.LettersOnlyError))]
        [StringLength(20, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 2)]
        public string Ime
        {
            get => _ime;
            set
            {
                if (ValidateProperty(nameof(Ime),value))
                {
                    SetProperty(ref _ime, value);
                }
            }
        }

        private string _prezime;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [LettersOnly(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.LettersOnlyError))]
        [StringLength(20, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 2)]
        public string Prezime
        {
            get => _prezime;
            set
            {
                if (ValidateProperty(nameof(Prezime),value))
                {
                    SetProperty(ref _prezime, value);
                }
            }
        }

        private string _username;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [StringLength(12, ErrorMessageResourceName = nameof(AppResources.UsernameLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 4)]
        public string Username
        {
            get => _username;
            set
            {
                if (ValidateProperty(nameof(Username),value))
                {
                    SetProperty(ref _username, value);
                }
            }
        }

        private string _password;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [StringLength(15, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 6)]
        public string Password
        {
            get => _password;
            set
            {
                if (ValidateProperty(nameof(Password),value))
                {
                    SetProperty(ref _password, value);
                }
            }
        }

        private string _confirmPassword;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [Compare(nameof(Password),ErrorMessageResourceType = typeof(AppResources),ErrorMessageResourceName = nameof(AppResources.PasswordDoNotMatchError))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (ValidateProperty(nameof(ConfirmPassword),value))
                {
                    SetProperty(ref _confirmPassword, value);
                }
            }
        }

        #endregion Properties
    }
}