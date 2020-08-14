using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage
    {
        private readonly WelcomeViewModel WelcomeVM;

        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = WelcomeVM = ViewModelLocator.WelcomeViewModel;
            LoadDataForCarouselView();
        }

        private void LoadDataForCarouselView()
        {
            WelcomeVM.ImageUrls = new ObservableCollection<SinglePropertyItemsViewModel<ImageSource>>
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
        }
    }
}