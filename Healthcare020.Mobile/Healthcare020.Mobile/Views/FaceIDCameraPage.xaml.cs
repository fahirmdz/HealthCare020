using System;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaceIDCameraPage : ContentPage
    {
        public FaceIDCameraPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }

        private async void CaptureButton_OnClicked(object sender, EventArgs e)
        {


        }
    }
}