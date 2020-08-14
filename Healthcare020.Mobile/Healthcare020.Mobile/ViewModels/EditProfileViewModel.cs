using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class EditProfileViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;

        public EditProfileViewModel()
        {
            //Init commands
            SaveCommand = new Command(async () => { await Save(); });
        }

        #region Methods

        public void Init()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                return;
            }

            _apiService = new APIService(Routes.LicniPodaciRoute);
        }

#pragma warning disable 1998

        public async Task Save()
#pragma warning restore 1998
        {
            if (!IsValidModel)
                return;
        }

        #endregion Methods

        #region Commands

        public ICommand SaveCommand { get; set; }

        #endregion Commands
    }
}