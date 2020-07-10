using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            Title = AppResources.ChangePasswordPageTitle;
            InitializeComponent();
            IconImageSource = IconFont.Key.GetIcon();
        }
    }
}