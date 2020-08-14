using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacijentDasbhboardTabbedPage
    {
        public PacijentDasbhboardTabbedPage()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            SelectedTabColor = (Color)Application.Current.Resources[ResourceKeys.HealthcareCyanColor];
            UnselectedTabColor = (Color)Application.Current.Resources[ResourceKeys.CustomNavyBlueDarkColor];
        }

        protected override void OnAppearing()
        {
            if (!Auth.IsAuthenticated())
            {
                NotificationService.Instance.Error(AppResources.UnauthenticatedAccessMessage);
                return;
            }
            base.OnAppearing();
        }
    }
}