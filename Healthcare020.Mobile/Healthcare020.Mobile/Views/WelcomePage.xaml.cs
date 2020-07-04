using System;
using System.Collections.Generic;
using Healthcare020.Mobile.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        private WelcomeViewModel WelcomeVM;

        public WelcomePage()
        {
            WelcomeVM=new WelcomeViewModel();
            BindingContext = WelcomeVM;
            InitializeComponent();
            LoadDataForCarouselView();
        }

        private void LoadDataForCarouselView()
        {
            WelcomeVM.ImageUrls= new ObservableCollection<SinglePropertyItemsViewModel<ImageSource>>
            {
                new SinglePropertyItemsViewModel<ImageSource>(){item= Device.RuntimePlatform==Device.Android?ImageSource.FromFile("welcome_poseta.png"):ImageSource.FromFile("Assets/welcome_Poseta.png")},
                new SinglePropertyItemsViewModel<ImageSource>(){
                    item= Device.RuntimePlatform==Device.Android?ImageSource.FromFile("welcome_stetoscope.png")
                    :ImageSource.FromFile("Assets/welcome_stetoscope.png")}
                };

            CarouselImages.ItemsSource = WelcomeVM.ImageUrls;
            Device.StartTimer(TimeSpan.FromSeconds(6), () =>
            {
                CarouselImages.Position = (CarouselImages.Position + 1) % WelcomeVM.ImageUrls.Count;
                return true;
            });

            LogoImage.Source = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("healthcare020_200x200.png")
                : ImageSource.FromFile("Assets/healthcare020_200x200.png");
        }
    }
}