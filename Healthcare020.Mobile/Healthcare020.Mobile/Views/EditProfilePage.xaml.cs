using Healthcare020.Mobile.Resources;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage
    {
        public EditProfilePage()
        {
            Title = AppResources.EditProfilePageTitle;
            InitializeComponent();
        }
    }
}