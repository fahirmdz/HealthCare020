using System.Diagnostics.Tracing;
using System.Windows.Input;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Models;
using Healthcare020.Mobile.Services;

namespace Healthcare020.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private PacijentDtoEL _pacijent;

        public PacijentDtoEL Pacijent
        {
            get => _pacijent;
            set => SetProperty(ref _pacijent, value);
        }

        public SettingsViewModel()
        {
        }

        public ICommand ProfilePicturePick { get; set; }

        public ICommand LogoutCommand { get; set; }

        //private void ProfilePicturePick(object sender, EventCommandEventArgs args)
        //{
        //    if (!CrossMedia.Current.IsPickPhotoSupported)
        //    {
        //        await DisplayAlert("no upload", "picking a photo is not supported", "ok");
        //        return;
        //    }

        //    var file = await CrossMedia.Current.PickPhotoAsync();
        //    if (file == null)
        //        return;
        //}
    }
}