using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Healthcare020.Mobile.Services;
using HealthCare020.Core.Models;
using System.Windows.Input;
using AutoMapper;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using Healthcare020.Mobile.Resources;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private PacijentDtoEL Pacijent;
        private readonly APIService _apiSerivce;
        private MediaFile UploadedPic;
        private readonly IMapper _mapper;

        public SettingsViewModel(IMapper mapper)
        {
            _mapper = mapper;
            var FontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            _apiSerivce=new APIService(Routes.PacijentiRoute);
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
            var pacijentResult = await _apiSerivce.Get<PacijentDtoEL>(new PacijentResourceParameters
            {
                EagerLoaded = true,
                KorisnickiNalogId = Auth.KorisnickiNalog.Id
            });

            if (pacijentResult.Succeeded && (pacijentResult.Data?.Any() ?? false))
            {
                Pacijent = pacijentResult.Data.First();
                ProfilePicImageSource=ImageSource.FromStream(() => new MemoryStream(Pacijent.ZdravstvenaKnjizica?.LicniPodaci?.ProfilePicture ?? Array.Empty<byte>()));
            }
        }

        private ImageSource _profilePicImageSource;
        public ImageSource ProfilePicImageSource
        {
            get => _profilePicImageSource;
            set => SetProperty( ref _profilePicImageSource, value);
        }

        public ICommand ProfilePicturePick =>new Command(async () =>
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            UploadedPic = await CrossMedia.Current.PickPhotoAsync();
            if (UploadedPic != null)
                await UpdateLicniPodaci();
        });

        public ICommand LogoutCommand => new Command(async () => { await Auth.Logout();});

        private async Task UpdateLicniPodaci()
        {
            _apiSerivce.ChangeRoute(Routes.LicniPodaciRoute);
            byte[] uploadedPicBytes=null;

            if (UploadedPic != null)
            {
                using (var ms = new MemoryStream())
                {
                    await UploadedPic.GetStream().CopyToAsync(ms);
                    uploadedPicBytes = ms.ToArray();
                }
            }

            var licniPodaci = Pacijent.ZdravstvenaKnjizica.LicniPodaci;
            var licniPodaciUpsertDto = _mapper.Map<LicniPodaciUpsertDto>(licniPodaci);

            licniPodaciUpsertDto.ProfilePicture = uploadedPicBytes;

            var updateResult = await _apiSerivce.Update<LicniPodaciDto>(Pacijent.ZdravstvenaKnjizica.LicniPodaci.Id, licniPodaciUpsertDto);

            if (updateResult.Succeeded)
            {
                ProfilePicImageSource = ImageSource.FromStream(()=>UploadedPic.GetStream());
            }
        }
    }
}