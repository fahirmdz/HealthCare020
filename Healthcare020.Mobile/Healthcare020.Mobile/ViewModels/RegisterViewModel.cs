using System.Collections.Generic;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ValidationAttributes;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class RegisterViewModel : BaseValidationViewModel
    {
        private readonly IAPIService _apiService;
        private readonly IFaceRecognitionService _faceRecognitionService;

        public RegisterViewModel(IAPIService apiService)
        {
            _faceRecognitionService=new FaceRecognitionService();
            _apiService = apiService;
            UploadProfilePictureCommand = new Command(async () => await UploadProfilePicture());
            RegisterCommand = new Command(async () => await Register());
            CancelRegistrationCommand = new Command(() => { Application.Current.MainPage = new WelcomePage(); });


            var profilePicIcon = IconFont.User.GetIcon();
            profilePicIcon.Color = (Color) Application.Current.Resources[ResourceKeys.HealthcareCyanColor];

            ProfilePicture = profilePicIcon;
        }

        #region Methods

        private async Task UploadProfilePicture()
        {
            MediaFile UploadedPic;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            try
            {
                UploadedPic = await CrossMedia.Current.PickPhotoAsync();
                if (UploadedPic != null)
                {
                    ProfilePicture = ImageSource.FromStream(() => UploadedPic.GetStream());
                    ProfilePictureAsBytes = UploadedPic.GetStream().AsByteArray();
                }
            }
            catch
            {
                //ignore
            }
        }

        private async Task Register()
        {
            if (ProfilePicture == null)
                return;

            this.EnabledLoadingSpinner = true;
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
                },
                ProfilePicture = ProfilePictureAsBytes
            };

            var result = await _apiService.Post<PacijentDtoLL>(upsertDto);
            IsBusy = false;
            this.EnabledLoadingSpinner = false;

            if (result.Succeeded)
            {
                await _faceRecognitionService.AddPersonToGruop(Username, ProfilePictureAsBytes);
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
        }

        #endregion Methods

        #region Commands

        public ICommand UploadProfilePictureCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand CancelRegistrationCommand { get; set; }

        #endregion Commands

        #region Properties

        private byte[] ProfilePictureAsBytes;

        private ImageSource _profilePicture;

        public ImageSource ProfilePicture
        {
            get => _profilePicture;
            set=>SetProperty(ref _profilePicture, value);

        }

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