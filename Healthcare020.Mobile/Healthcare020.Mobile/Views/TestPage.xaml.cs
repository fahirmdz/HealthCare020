using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
using Healthcare020.Mobile.Views.Dialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestViewModel TestVM;

        public TestPage()
        {
            InitializeComponent();
            BindingContext = TestVM=new TestViewModel();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }


        private async void PicToAdd_TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            MediaFile UploadedPic;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            try
            {
                UploadedPic = await CrossMedia.Current.PickPhotoAsync();
                if (UploadedPic != null)
                {
                    if (string.IsNullOrWhiteSpace(PictureToAddImePrezime.Text))
                        return;

                    TestVM.PictureToAdd = ImageSource.FromStream(() => UploadedPic.GetStream());
                    TestVM.PictureToAddAsBytes = UploadedPic.GetStream().AsByteArray();
                }
            }
            catch
            {
                //ignore
            }
        }

        private async void PicToIdentify_TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            MediaFile UploadedPic;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            try
            {
                UploadedPic = await CrossMedia.Current.PickPhotoAsync();
                if (UploadedPic != null)
                {
                    TestVM.PictureToIdentify = ImageSource.FromStream(() => UploadedPic.GetStream());
                    TestVM.PictureToIdentifyAsBytes = UploadedPic.GetStream().AsByteArray();
                }
            }
            catch
            {
                //ignore
            }
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

        }

        private async void CreatePersonGroupButton_OnClicked(object sender, EventArgs e)
        {

        }

        private void WelcomeBtn_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage=new WelcomePage();
        }

        private async void DialogButton_OnClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(new AnimationDialogPage(Application.Current.Resources[ResourceKeys.PregledAnimationPath] as OnPlatform<string>));
        }
    }
}