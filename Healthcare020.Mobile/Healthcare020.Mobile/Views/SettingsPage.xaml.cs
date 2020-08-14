using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using System;
using System.Threading.Tasks;
using Healthcare020.Mobile.Views.Dialogs;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage
    {
        public SettingsViewModel SettingsVM { get; set; }
        private NavigationPage NavigationPageParent;

        public SettingsPage()
        {
            Title = AppResources.SettingsPageTitle;
            InitializeComponent();
            BindingContext = SettingsVM = ViewModelLocator.SettingsViewModel;

            //Set icons on buttons
            LicniPodaciBtn.ImageSource = IconFont.User.GetIcon(20);
            EditProfileBtn.ImageSource = IconFont.Edit.GetIcon(20);
            ChangePasswordBtn.ImageSource = IconFont.Key.GetIcon(20);
        }

        protected override void OnAppearing()
        {
            SettingsVM.InitializeAsync();
            base.OnAppearing();
            NavigationPageParent = (NavigationPage)Parent;
        }

        private async void ChangePasswordBtn_OnClicked(object sender, EventArgs e)
        {
            await NavigationPageParent.PushAsync(new ChangePasswordPage(),true);
        }

        private async void EditProfileBtn_OnClicked(object sender, EventArgs e)
        {
            await NavigationPageParent.PushAsync(new EditProfilePage(),true);
        }

        private void DeleteAccountLabel_OnTapped(object sender, EventArgs e)
        {
            SettingsVM.PasswordCheckNavigationCommand.Execute(sender);
        }

        private async void LicniPodaciBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new LicniPodaciDialogPage());
        }
    }
}