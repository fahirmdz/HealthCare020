using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Models;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Healthcare020.Mobile.Views.Dialogs;
using HealthCare020.Core.ResourceParameters;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreglediPage
    {
        public bool OnlyZakazani { get; set; }
        public PreglediViewModel PreglediVM { get; set; }

        public PreglediPage(bool OnlyZakazani = false)
        {
            this.OnlyZakazani = OnlyZakazani;
            Title = OnlyZakazani ? AppResources.ZakazaniPreglediPageTitle : AppResources.SviPreglediPageTitle;
            InitializeComponent();
            BindingContext = PreglediVM = ViewModelLocator.PreglediViewModel;
            ((PregledResourceParameters)PreglediVM.ResourceParameters).OnlyZakazani = this.OnlyZakazani;
            PreglediVM.SearchEntryPlaceholder = AppResources.SearchByDoktor;

            ListView.MainListView.ItemTapped += async (sender, e) =>
                {
                    await Navigation.PushPopupAsync(new PregledDialogPage((e.Item as CollectionViewItem)?.Id ?? 0));
                };
        }

        protected override async void OnAppearing()
        {
            await PreglediVM.Init();
            ResourceKeys.FlagIconsStyle.ChangeStyleSetterValue(nameof(IsVisible), true);
            base.OnAppearing();
        }
    }
}