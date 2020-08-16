using AutoMapper;
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.Views.Dialogs;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private APIService _apiSerivce;
        private MediaFile UploadedPic;
        private readonly IMapper _mapper;

        public SettingsViewModel()
        {
            _mapper = Bootstrap.GetContainer().Resolve<IMapper>();

            var UserCircleIcon = IconFont.UserCircle.GetIcon(70);
            UserCircleIcon.Color = (Color)Application.Current.Resources[ResourceKeys.CustomNavyBlueDarkColor];

            ProfilePicImageSource = UserCircleIcon;
            UploadedPic = null;

            //Init commands
            DeleteAccountCommand = new Command(async () => { await DeleteAccount(); });
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
                NotificationService.Instance.Toast(AppResources.Success);
            }
            else
            {
                NotificationService.Instance.Error(AppResources.Error);
            }
        }

        public void InitializeAsync()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }
            _apiSerivce=new APIService();
            Pacijent = Auth.Pacijent;
            var profPic = Pacijent.ZdravstvenaKnjizica?.LicniPodaci?.ProfilePicture;
            if(profPic==null || !profPic.Any())
                ProfilePicImageSource=IconFont.UserCircle.GetIcon();
            else
            {
                ProfilePicImageSource = ImageSource.FromStream(() => new MemoryStream(profPic));
            }
        }

        public async Task DeleteAccount()
        {
            if ((await NotificationService.Instance.Prompt())?.Ok ?? false)
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

        #endregion Methods

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

        #endregion Properties

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

        #endregion Commands
    }
}