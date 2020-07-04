using System.Collections.ObjectModel;
using System.Windows.Input;
using Healthcare020.Mobile.Views;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class WelcomeViewModel:BaseViewModel
    {
        public WelcomeViewModel()
        {
            LoginPageCommand=new Command(() =>
            {
                Application.Current.MainPage = new LoginPage();
            });

            RegisterPageCommand=new Command(() =>
            {
                Application.Current.MainPage = new LoginPage();
            });

            PosetaPageCommand=new Command(() =>
            {
                Application.Current.MainPage = new LoginPage();
            });
        }

        private ObservableCollection<SinglePropertyItemsViewModel<ImageSource>> _imageUrls;
        public ObservableCollection<SinglePropertyItemsViewModel<ImageSource>> ImageUrls
        {
            get => _imageUrls;
            set => SetProperty(ref _imageUrls, value);
        }

        public ICommand LoginPageCommand { get; set; }
        public ICommand RegisterPageCommand { get; set; }
        public ICommand PosetaPageCommand { get; set; }
    }
}