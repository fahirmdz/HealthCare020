using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Models;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Healthcare020.Mobile.Views.Dialogs;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LekarskaUverenjaMainPage
    {
        public LekarskaUverenjaViewModel LekarskaUverenjaVM { get; set; }

        public LekarskaUverenjaMainPage()
        {
            Title = AppResources.LekarskaUverenjaPageTitle;
            InitializeComponent();
            BindingContext = LekarskaUverenjaVM = ViewModelLocator.LekarskaUverenjaViewModel;
            LekarskaUverenjaVM.SearchEntryPlaceholder = AppResources.SearchByOpisStanja;

            ListView.MainListView.ItemTapped += async (sender, e) =>
            {
                await Navigation.PushPopupAsync(new LekarskoUverenjeDialogPage((e.Item as CollectionViewItem)?.Id ?? 0));
            };
        }

        protected override async void OnAppearing()
        {
            ResourceKeys.FlagIconsStyle.ChangeStyleSetterValue(nameof(IsVisible), false);

            base.OnAppearing();
            await LekarskaUverenjaVM.Init();
        }
    }
}