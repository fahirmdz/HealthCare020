using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class TestViewModel:BaseViewModel
    {
        public TestViewModel()
        {
            PictureToAdd = IconFont.UserCircle.GetIcon();
            PictureToIdentify = IconFont.UserAlt.GetIcon();
        }
        public byte[] PictureToAddAsBytes;
        private ImageSource _pictureToAdd;
        public ImageSource PictureToAdd
        {
            get => _pictureToAdd;
            set => SetProperty(ref _pictureToAdd,value);
        }

        public byte[] PictureToIdentifyAsBytes;
        private ImageSource _pictureToIdentify;
        public ImageSource PictureToIdentify
        {
            get => _pictureToIdentify;
            set => SetProperty(ref _pictureToIdentify,value);
        }
    }
}