using System;
using Acr.UserDialogs;
using AutoMapper;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Views.Dialogs;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private  APIService _apiSerivce;
        private MediaFile UploadedPic;
        private readonly IMapper _mapper;

        public SettingsViewModel(IMapper mapper)
        {
            _mapper = mapper;
            var UserCircleIcon = IconFont.UserCircle.GetIcon(70);
            UserCircleIcon.Color = (Color) Application.Current.Resources[ResourceKeys.CustomNavyBlueDarkColor];

            ProfilePicImageSource = UserCircleIcon;
            UploadedPic = null;

            //Init commands
            DeleteAccountCommand=new Command(async () => { await DeleteAccount();});
            PasswordCheckNavigationCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushPopupAsync(
                    new PasswordCheckDialogPage(DeleteAccountCommand));
            });
        }

        #region Methods

        private async Task UpdateLicniPodaci()
        {
            _apiSerivce.ChangeRoute(Routes.LicniPodaciRoute);
            byte[] uploadedPicBytes = null;

            if (UploadedPic != null)
            {
                using var ms = new MemoryStream();
                await UploadedPic.GetStream().CopyToAsync(ms);
                uploadedPicBytes = ms.ToArray();
            }

            var licniPodaci = Pacijent.ZdravstvenaKnjizica.LicniPodaci;
            var licniPodaciUpsertDto = _mapper.Map<LicniPodaciUpsertDto>(licniPodaci);

            licniPodaciUpsertDto.ProfilePicture = uploadedPicBytes;

            var updateResult = await _apiSerivce.Update<LicniPodaciDto>(Pacijent.ZdravstvenaKnjizica.LicniPodaci.Id, licniPodaciUpsertDto);

            if (updateResult.Succeeded)
            {
                ProfilePicImageSource = ImageSource.FromStream(() => UploadedPic.GetStream());
            }

            var toastCfg = new ToastConfig(AppResources.Success)
            {
                Position = ToastPosition.Top,
                MessageTextColor = System.Drawing.Color.White
            };
            UserDialogs.Instance.Toast(toastCfg);
        }

        public async Task InitializeAsync()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }
            _apiSerivce = new APIService(Routes.PacijentiRoute);

            var pacijentResult = await _apiSerivce.Get<PacijentDtoEL>(new PacijentResourceParameters
            {
                EagerLoaded = true,
                KorisnickiNalogId = Auth.KorisnickiNalog?.Id
            });
            //Pacijent = DevelopmentTestEntities.GetTestPacijent();

            if (pacijentResult.Succeeded && (pacijentResult.Data?.Any() ?? false))
            {
                Pacijent = pacijentResult.Data.First();
                var imgSourceForProfilePic = ImageSource.FromStream(() =>
                    new MemoryStream(Pacijent.ZdravstvenaKnjizica?.LicniPodaci?.ProfilePicture ?? Array.Empty<byte>()));

                if (imgSourceForProfilePic.IsEmpty)
                    imgSourceForProfilePic = IconFont.UserCircle.GetIcon();
                ProfilePicImageSource = imgSourceForProfilePic;
            }
        }

        public async Task DeleteAccount()
        {
            if((await NotificationService.Instance.Prompt())?.Ok ?? false)
            {
                _apiSerivce.ChangeRoute(Routes.PacijentiRoute);
                var result = await _apiSerivce.Delete<int>(0);
                if (result.StatusCode != HttpStatusCode.NoContent)
                {
                    NotificationService.Instance.Error(AppResources.Error);
                    return;
                }

                await Auth.Logout();
            }
        }

        #endregion

        #region Properties
        private ImageSource _profilePicImageSource;
        public ImageSource ProfilePicImageSource
        {
            get => _profilePicImageSource;
            set => SetProperty(ref _profilePicImageSource, value);
        }

        private PacijentDtoEL _pacijent;

        public PacijentDtoEL Pacijent
        {
            get => _pacijent;
            set => SetProperty(ref _pacijent, value);
        }

        #endregion




        #region Commands
        public ICommand PasswordCheckNavigationCommand { get; set; }
        public ICommand DeleteAccountCommand { get; }
        public ICommand LogoutCommand => new Command(async () => { await Auth.Logout(); });
        public ICommand ProfilePicturePick => new Command(async () =>
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            try
            {
                UploadedPic = await CrossMedia.Current.PickPhotoAsync();
                if (UploadedPic != null)
                    await UpdateLicniPodaci();
            }
            catch
            {
                //ignore
            }
        });
        #endregion

    }
}