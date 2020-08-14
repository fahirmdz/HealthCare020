using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class NoviZahtevZaPregledViewModel : BaseValidationViewModel
    {
        private IAPIService _apiService;

        public NoviZahtevZaPregledViewModel()
        {
            //Init commands
            InitCommand = new Command(async () => await Init());
            SaveCommand = new Command(async () => await Save());
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

            _apiService.ChangeRoute(Routes.DoktoriRoute);
            var result = await _apiService.Get<DoktorDtoEL>(new DoktorResourceParameters { EagerLoaded = true });

            if (result.Succeeded)
            {
                Doktori = result.HasData ? result.Data : new List<DoktorDtoEL>();
            }
            else
            {
                NotificationService.Instance.Error(AppResources.UnableToLoadDataError);
            }
        }

        private async Task Save()
        {
            IsBusy = true;
            if (!IsValidModel)
                return;

            MainBodyVisible = false;

            _apiService.ChangeRoute(Routes.ZahteviZaPregledRoute);
            var upsertDto = new ZahtevZaPregledUpsertDto
            {
                DoktorId = PickedDoktor.Id,
                Napomena = Napomena
            };

            var result = await _apiService.Post<ZahtevZaPregledDtoLL>(upsertDto);

            await Task.Delay(3000);
            IsBusy = false;

            if (result.Succeeded)
            {
                NotificationService.Instance.Success(AppResources.SuccessfullyCreatedZahtevZaPregledMessage);
                await Task.Delay(200);
                await Application.Current.MainPage.PopToRootCurrentTabAsNavigationPage();
            }
            else
            {
                NotificationService.Instance.Error(result.StatusCode == HttpStatusCode.BadRequest
                    ? result.Message
                    : string.Empty);
            }
        }

        #endregion Methods

        #region Properties

        private IList<DoktorDtoEL> _doktori;

        public IList<DoktorDtoEL> Doktori
        {
            get => _doktori;
            set => SetProperty(ref _doktori, value);
        }

        private DoktorDtoEL _pickedDoktor;

        [Required(ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.RequiredFieldError))]
        public DoktorDtoEL PickedDoktor
        {
            get => _pickedDoktor;
            set
            {
                if (ValidateProperty(nameof(PickedDoktor), value))
                    SetProperty(ref _pickedDoktor, value);
            }
        }

        private string _napomena;

        [MaxLength(180, ErrorMessageResourceType = typeof(AppResources), ErrorMessageResourceName = nameof(AppResources.MaxLength180Error))]
        public string Napomena
        {
            get => _napomena;
            set
            {
                if (ValidateProperty(nameof(Napomena), value))
                    SetProperty(ref _napomena, value);
            }
        }

        #endregion Properties

        #region Commands

        public ICommand InitCommand { get; }
        public ICommand SaveCommand { get; }

        #endregion Commands

        #region Properties

        private bool _mainBodyVisible = true;

        public bool MainBodyVisible
        {
            get => _mainBodyVisible;
            set => SetProperty(ref _mainBodyVisible, value);
        }

        #endregion Properties
    }
}