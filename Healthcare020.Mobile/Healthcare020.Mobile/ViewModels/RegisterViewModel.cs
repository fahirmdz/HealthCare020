using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class RegisterViewModel : BaseValidationViewModel
    {
        private readonly IAPIService _apiService;

        public RegisterViewModel(IAPIService apiService)
        {
            _apiService = apiService;
        }

        #region Commands

        public ICommand RegisterCommand => new Command(async () =>
        {
            IsBusy = true;
            if (!IsValidModel)
                return;

            _apiService.ChangeRoute(Routes.PacijentiRoute);
            var upsertDto = new PacijentUpsertDto
            {
                Ime = Ime,
                Prezime = Prezime,
                BrojZdravstveneKnjizice = int.Parse(BrojKnjizice),
                JMBG = JMBG,
                KorisnickiNalog = new KorisnickiNalogUpsertDto
                {
                    Username = Username,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword
                }
            };

            var result = await _apiService.Post<PacijentDtoLL>(upsertDto);
            IsBusy = false;

            if (result.Succeeded)
            {
                NotificationService.Instance.Success(AppResources.SuccessfullyCreatedAccount);
                await Task.Delay(100);
                Application.Current.MainPage = new PacijentDasbhboardTabbedPage();
            }
            else
            {
                NotificationService.Instance.Error(result.StatusCode == HttpStatusCode.BadRequest
                    ? result.Message
                    : string.Empty);
            }
        });

        public ICommand CancelRegistrationCommand => new Command(() =>
        {
        });

        #endregion Commands

        #region Properties

        private string _brojKnjizice;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [DigitsOnly(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.DigitsOnlyError))]
        public string BrojKnjizice
        {
            get => _brojKnjizice;
            set
            {
                if (ValidateProperty(nameof(BrojKnjizice), value))
                {
                    SetProperty(ref _brojKnjizice, value);
                }
            }
        }

        private string _jmbg;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [DigitsOnly(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.DigitsOnlyError))]
        public string JMBG
        {
            get => _jmbg;
            set
            {
                if (ValidateProperty(nameof(JMBG), value))
                {
                    SetProperty(ref _jmbg, value);
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
                if (ValidateProperty(nameof(Ime), value))
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
                if (ValidateProperty(nameof(Prezime), value))
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
                if (ValidateProperty(nameof(Username), value))
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
                if (ValidateProperty(nameof(Password), value))
                {
                    SetProperty(ref _password, value);
                }
            }
        }

        private string _confirmPassword;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [Compare(nameof(Password), ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.PasswordDoNotMatchError))]
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                if (ValidateProperty(nameof(ConfirmPassword), value))
                {
                    SetProperty(ref _confirmPassword, value);
                }
            }
        }

        #endregion Properties
    }
}