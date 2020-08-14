using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using Rg.Plugins.Popup.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Healthcare020.Mobile.ViewModels
{
    public class PasswordCheckViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;
        private ICommand CommandToExecute;

        #region Methods

        public bool ValidInput() => !string.IsNullOrWhiteSpace(Password);

        public void Init(ICommand commandToExecute)
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }

            CommandToExecute = commandToExecute;
            _apiService = new APIService();
        }

        public async Task CheckPassword()
        {
            if (!ValidInput())
                return;

            _apiService.ChangeRoute($"{Routes.KorisniciRoute}/{Routes.CheckPasswordRoute}");

            var result = await _apiService.Post<int>(Password);

            if (!result.Succeeded && result.StatusCode == HttpStatusCode.BadRequest)
            {
                NotificationService.Instance.Error(result.Message);
                return;
            }

            CommandToExecute?.Execute(null);
            await PopupNavigation.Instance.PopAsync();
        }

        #endregion Methods

        #region Properties

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

        #endregion Properties
    }
}