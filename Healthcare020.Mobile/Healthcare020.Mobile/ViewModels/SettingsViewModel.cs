using Acr.UserDialogs;
using AutoMapper;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly APIService _apiSerivce;
        private MediaFile UploadedPic;
        private readonly IMapper _mapper;

        public SettingsViewModel(IMapper mapper)
        {
            _mapper = mapper;
            var FontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            //_apiSerivce=new APIService(Routes.PacijentiRoute);
            _profilePicImageSource = new FontImageSource
            {
                FontFamily = FontAwesomeRegular,
                Glyph = IconFont.UserCircle,
                Color = Color.FromRgb(83, 107, 128),
                Size = 70
            };

            InitializeAsync();
            UploadedPic = null;
        }

        public async void InitializeAsync()
        {
            //var pacijentResult = await _apiSerivce.Get<PacijentDtoEL>(new PacijentResourceParameters
            //{
            //    EagerLoaded = true,
            //    KorisnickiNalogId = Auth.KorisnickiNalog.Id
            //});

            //if (pacijentResult.Succeeded && (pacijentResult.Data?.Any() ?? false))
            //{
            //    Pacijent = pacijentResult.Data.First();
            //    ProfilePicImageSource=ImageSource.FromStream(() => new MemoryStream(Pacijent.ZdravstvenaKnjizica?.LicniPodaci?.ProfilePicture ?? Array.Empty<byte>()));
            //}
            Pacijent = DevelopmentTestEntities.GetTestPacijent();
            ProfilePicImageSource = ImageSource.FromStream(() =>
                  new MemoryStream(Pacijent.ZdravstvenaKnjizica.LicniPodaci.ProfilePicture));
        }

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

        public ICommand LogoutCommand => new Command(async () => { await Auth.Logout(); });

        private async Task UpdateLicniPodaci()
        {
            //_apiSerivce.ChangeRoute(Routes.LicniPodaciRoute);
            //byte[] uploadedPicBytes=null;

            //if (UploadedPic != null)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        await UploadedPic.GetStream().CopyToAsync(ms);
            //        uploadedPicBytes = ms.ToArray();
            //    }
            //}

            //var licniPodaci = Pacijent.ZdravstvenaKnjizica.LicniPodaci;
            //var licniPodaciUpsertDto = _mapper.Map<LicniPodaciUpsertDto>(licniPodaci);

            //licniPodaciUpsertDto.ProfilePicture = uploadedPicBytes;

            //var updateResult = await _apiSerivce.Update<LicniPodaciDto>(Pacijent.ZdravstvenaKnjizica.LicniPodaci.Id, licniPodaciUpsertDto);

            //if (updateResult.Succeeded)
            //{
            //    ProfilePicImageSource = ImageSource.FromStream(()=>UploadedPic.GetStream());
            //}

            ProfilePicImageSource = ImageSource.FromStream(() => UploadedPic.GetStream());
            var toastCfg = new ToastConfig("Uspesno")
            {
                Position = ToastPosition.Top,
                MessageTextColor = System.Drawing.Color.White
            };
            UserDialogs.Instance.Toast(toastCfg);
        }
    }
}