using Healthcare020.Mobile.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Healthcare020.Mobile.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private ObservableCollection<SinglePropertyItemsViewModel<ImageSource>> _imageUrls;

        public ObservableCollection<SinglePropertyItemsViewModel<ImageSource>> ImageUrls
        {
            get => _imageUrls;
            set => SetProperty(ref _imageUrls, value);
        }

        public ICommand LoginPageCommand => new Command(() =>
          {
              Application.Current.MainPage = new LoginPage();
          });

        public ICommand RegisterPageCommand => new Command(() =>
          {
              Application.Current.MainPage = new RegisterPage();
          });

        public ICommand PosetaPageCommand => new Command(() =>
          {
              Application.Current.MainPage = new PosetaPage();
          });
    }
}