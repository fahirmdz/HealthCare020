using System;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsViewModel SettingsVM { get; set; }
        private readonly OnPlatform<string> FontAwesomeRegular;

        public SettingsPage()
        {
            //_apiService = new APIService(Routes.PacijentiRoute);
            InitializeComponent();
            BindingContext = SettingsVM = ViewModelLocator.SettingsViewModel;
            FontAwesomeRegular = Application.Current.Resources["FontAwesomeRegular"] as OnPlatform<string>;

            LogoutBtn.ImageSource = GetIconSource(IconFont.SignOutAlt);

            EditProfileBtn.ImageSource = GetIconSource(IconFont.Edit);

            ChangePasswordBtn.ImageSource = GetIconSource(IconFont.Key);
        }

        private FontImageSource GetIconSource(string glyph) => new FontImageSource
        {
            FontFamily = FontAwesomeRegular,
            Glyph = glyph,
            Color=Color.WhiteSmoke,
            Size=30
        };

        private async void ChangePasswordBtn_OnClicked(object sender, EventArgs e)
        {
            await ((NavigationPage)this.Parent).PushAsync(new EditProfilePage());
        }
    }
}