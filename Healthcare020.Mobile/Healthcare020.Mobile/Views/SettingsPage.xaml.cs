using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel SettingsVM { get; set; }
        private NavigationPage NavigationPageParent;

        public SettingsPage()
        {
            Title = AppResources.SettingsPageTitle;
            InitializeComponent();
            BindingContext = SettingsVM = ViewModelLocator.SettingsViewModel;

            LogoutBtn.ImageSource = IconFont.SignOutAlt.GetIcon();

            EditProfileBtn.ImageSource = IconFont.Edit.GetIcon(); ;

            ChangePasswordBtn.ImageSource = IconFont.Key.GetIcon(); ;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPageParent = (NavigationPage)Parent;
        }

        private async void ChangePasswordBtn_OnClicked(object sender, EventArgs e)
        {
            await PushToNavigationParent(new ChangePasswordPage());
        }

        private async void EditProfileBtn_OnClicked(object sender, EventArgs e)
        {
            await PushToNavigationParent(new EditProfilePage());
        }

        private async Task PushToNavigationParent(Page page)
        {
            await NavigationPageParent.PushAsync(page, true);
        }
    }
}