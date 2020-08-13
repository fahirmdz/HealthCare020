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
using Healthcare020.Mobile.Constants;
using Plugin.Media;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class LoginViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;

        public LoginViewModel()
        {
            _apiService = new APIService();
            //Init commands
            LoginCommand = new Command(async () => await Login());
            RegisterNavigationCommand = new Command(() => Application.Current.MainPage = new RegisterPage());
            FaceIDLoginCommand = new Command(async () => await FaceIDLogin());
        }

        #region Methods

        public async Task FaceIDLogin()
        {
            //var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(
            //    new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            var photo = await CrossMedia.Current.PickPhotoAsync();

            if (photo == null)
                return;

            this.IsBusy = true;
            this.MainBodyVisible = false;
            this.AnimationFrameVisible = true;

            SelfieForFaceID = photo.GetStream().AsByteArray();

            _apiService.ChangeRoute(Routes.PacijentiRoute);
            var result = await _apiService.Get<PacijentDtoEL>(new PacijentResourceParameters
            {
                EagerLoaded = true,
            });

            await Task.Delay(3500);

            if (!result.Succeeded || !result.HasData)
            {
                IsBusy = false;
                this.MainBodyVisible = true;
                this.AnimationFrameVisible = false;

                await Task.Delay(100);
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }

            if (!await Auth.AuthenticateWithFaceID(SelfieForFaceID))
            {
                IsBusy = false;
                this.MainBodyVisible = true;
                this.AnimationFrameVisible = false;

                await Task.Delay(100);
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }
            this.MainBodyVisible = false;
            this.AnimationFrameVisible = false;
            this.AnimationSuccessFrameVisible = true;
            await Task.Delay(2850);
            this.IsBusy = false;

            Application.Current.MainPage=new PacijentDasbhboardTabbedPage();
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

            //Face scanned
            MainAnimationPath=Application.Current.Resources[ResourceKeys.FaceIdAnimationPath] as OnPlatform<string>;
            await Task.Delay(1500);

            IsBusy = false;
        }

        #endregion Methods

        #region Properties

        private string _mainAnimationPath =
            Application.Current.Resources[ResourceKeys.ScanFaceAnimationPath] as OnPlatform<string>;
        public string MainAnimationPath
        {
            get => _mainAnimationPath;
            set => SetProperty(ref _mainAnimationPath, value);
        }

        private bool _mainBodyVisible = true;
        public bool MainBodyVisible
        {
            get => _mainBodyVisible;
            set => SetProperty(ref _mainBodyVisible, value);
        }

        private bool _animationSuccessFrameVisible;
        public bool AnimationSuccessFrameVisible
        {
            get => _animationSuccessFrameVisible;
            set => SetProperty(ref _animationSuccessFrameVisible, value);
        }

        private bool _animationFrameVisible;
        public bool AnimationFrameVisible
        {
            get => _animationFrameVisible;
            set => SetProperty(ref _animationFrameVisible, value);
        }

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