using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Request;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using HealthCare020.Core.ValidationAttributes;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class ChangePasswordViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;
        public StackLayout FormBody;

        public ChangePasswordViewModel()
        {
            ChangePasswordCommand = new Command(async () => { await ChangePassword(); });
        }

        #region Methods

        public async Task Init()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }

            _apiService = new APIService();
        }

        public async Task ChangePassword()
        {
            if (!IsValidModel)
                return;
            IsBusy = true;
            MainBodyVisible = false;

            _apiService.ChangeRoute($"{Routes.KorisniciRoute}/{Routes.ChangePasswordRoute}");
            var result = await _apiService.Post<int>(new ChangePasswordDto
            {
                CurrentPassword = OldPassword,
                NewPassword = NewPassword
            });

            //Animation waiting
            await Task.Delay(2500);
            IsBusy = false;

            if (!result.Succeeded)
            {
                MainBodyVisible = true;
                NotificationService.Instance.Error(result.StatusCode == HttpStatusCode.BadRequest
                    ? result.Message
                    : AppResources.Error);
            }
            else
            {
                NotificationService.Instance.Success();
                await Application.Current.MainPage.PopToRootCurrentTabAsNavigationPage();
            }
        }

        #endregion Methods

        #region Commands

        public ICommand ChangePasswordCommand { get; set; }

        #endregion Commands

        #region Properties
        private bool _mainBodyVisible = true;
        public bool MainBodyVisible
        {
            get => _mainBodyVisible;
            set => SetProperty(ref _mainBodyVisible, value);
        }


        private string _oldPassword;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [StringLength(15, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 6)]
        public string OldPassword
        {
            get => _oldPassword;
            set
            {
                if (ValidateProperty(nameof(OldPassword), value))
                {
                    SetProperty(ref _oldPassword, value);
                }
            }
        }

        private string _newPassword;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [Different(nameof(OldPassword),ErrorMessageResourceType = typeof(AppResources),ErrorMessageResourceName = "NewPasswordSameAsOldValidationError")]
        [StringLength(15, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 6)]
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                if (ValidateProperty(nameof(NewPassword), value))
                {
                    SetProperty(ref _newPassword, value);
                }
            }
        }

        private string _newPasswordConfirm;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [Compare(nameof(NewPassword), ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.PasswordDoNotMatchError))]
        public string NewPasswordConfirm
        {
            get => _newPasswordConfirm;
            set
            {
                if (ValidateProperty(nameof(NewPasswordConfirm), value))
                {
                    SetProperty(ref _newPasswordConfirm, value);
                }
            }
        }

        #endregion Properties
    }
}