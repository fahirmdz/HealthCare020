using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class LoginViewModel : BaseValidationViewModel
    {
        private IFaceRecognitionService _faceRecognitionService;
        private IAPIService _apiService;

        public LoginViewModel()
        {
            _apiService = new APIService();
            _faceRecognitionService = new FaceRecognitionService();
            //Init commands
            LoginCommand = new Command(async () => await Login());
            RegisterNavigationCommand = new Command(() => Application.Current.MainPage = new RegisterPage());
            FaceIDLoginCommand = new Command(async () => await FaceIDLogin());
        }

        #region Methods

        public async Task FaceIDLogin()
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            //var photo = await CrossMedia.Current.PickPhotoAsync();

            if (photo == null)
                return;

            this.EnabledLoadingSpinner = true;
            this.IsBusy = true;

            SelfieForFaceID = photo.GetStream().AsByteArray();

            var authenticatedPerson = await _faceRecognitionService.IdentifyFace(SelfieForFaceID);

            if (authenticatedPerson == null)
            {
                IsBusy = false;
                this.EnabledLoadingSpinner = false;
                await Task.Delay(100);
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }

            _apiService.ChangeRoute(Routes.PacijentiRoute);
            var result = await _apiService.Get<PacijentDtoEL>(new PacijentResourceParameters
            {
                EagerLoaded = true,
                Username = authenticatedPerson.Name
            });

            if (!result.Succeeded || !result.HasData)
            {
                IsBusy = false;
                this.EnabledLoadingSpinner = false;
                await Task.Delay(100);
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }

            var pacijent = result.Data.FirstOrDefault();

            _apiService.ChangeRoute(Routes.FaceRecognitionRecordsRoute);
            var insertFaceIdRecognitionRecords = await _apiService.Post<FaceRecognitionDto>(
                new FaceRecognitionRecordUpsertDto
                {
                    KorisnickiNalogId = pacijent.KorisnickiNalogId,
                    Key = AppResources.ServiceIdentificationSecret.Encrypt(AppResources.RSAPublicKeyXml)
                });

            if (!insertFaceIdRecognitionRecords.Succeeded)
            {
                IsBusy = false;
                this.EnabledLoadingSpinner = false;
                await Task.Delay(100);
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }

            if (await Auth.AuthenticateWithPassword(pacijent.Username, pacijent.FaceId))
            {
                Application.Current.MainPage = new PacijentDasbhboardTabbedPage();
            }
            else
            {
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
            }
            this.IsBusy = false;
            this.EnabledLoadingSpinner = false;
        }

        public async Task Login()
        {
            IsBusy = true;

            if (!IsValidModel)
                return;

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

        #endregion Methods

        #region Properties

        private byte[] SelfieForFaceID;

        private string _username;

        [Required(ErrorMessageResourceType = typeof(AppResources),
            ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
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

        [Required(ErrorMessageResourceType = typeof(AppResources),
            ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
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

        public ICommand LoginCommand { get; }

        public ICommand RegisterNavigationCommand { get; }

        public ICommand FaceIDLoginCommand { get; }

        #endregion Commands
    }
}