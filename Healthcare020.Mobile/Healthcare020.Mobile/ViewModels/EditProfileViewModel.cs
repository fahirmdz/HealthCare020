using AutoMapper;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class EditProfileViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;
        public LicniPodaciDto LicniPodaci;
        private readonly IMapper _mapper;

        public EditProfileViewModel()
        {
            _mapper = Bootstrap.GetContainer().Resolve<IMapper>();

            //Init commands
            SaveCommand = new Command(async () => { await Save(); });
            CancelNavigationCommand = new Command(async () =>
            {
                await Application.Current.MainPage.PopToRootCurrentTabAsNavigationPage();
            });
        }

        #region Methods

        public async void Init()
        {
            if (!Auth.IsAuthenticated(false))
            {
                if (!await Auth.AuthenticateWithPassword("fahirmdz", "testtest"))
                {
                    NotificationService.Instance.Error(AppResources.UnsuccessfullyAuthentication);
                    return;
                }
            }

            _apiService = new APIService(Routes.LicniPodaciRoute);
            LicniPodaci = Auth.Pacijent?.ZdravstvenaKnjizica?.LicniPodaci;
        }

        public async Task Save()
        {
            if (!IsValidModel)
                return;

            var licniPodaciUpsertDto = _mapper.Map<LicniPodaciDto, LicniPodaciUpsertDto>(LicniPodaci);
            licniPodaciUpsertDto.EmailAddress = EmailAddress;

            var result = await _apiService.Update<LicniPodaciDto>(LicniPodaci.Id, licniPodaciUpsertDto);

            if (!result.Succeeded)
            {
                NotificationService.Instance.Error(result.StatusCode == HttpStatusCode.BadRequest || (int)result.StatusCode == 422
                    ? result.Message
                    : AppResources.Error);

                return;
            }
            NotificationService.Instance.Success(AppResources.Success);
            await Application.Current.MainPage.PopToRootCurrentTabAsNavigationPage();
        }

        #endregion Methods

        #region Commands

        public ICommand SaveCommand { get; set; }
        public ICommand CancelNavigationCommand { get; set; }

        #endregion Commands

        #region Properties

        private string _emailAddress;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        [StringLength(30, ErrorMessageResourceName = nameof(AppResources.PasswordLengthError), ErrorMessageResourceType = typeof(AppResources), MinimumLength = 6)]
        [EmailAddress(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = "InvalidEmailAddressFormat")]
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                if (ValidateProperty(nameof(EmailAddress), value))
                {
                    SetProperty(ref _emailAddress, value);
                }
            }
        }

        #endregion Properties
    }
}