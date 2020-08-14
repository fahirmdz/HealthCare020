using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LicniPodaciDialogPage
    {
        public LicniPodaciViewModel LicniPodaciVM;

        public LicniPodaciDialogPage()
        {
            InitializeComponent();
            BindingContext = LicniPodaciVM = ViewModelLocator.LicniPodaciViewModel;
            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            HasKeyboardOffset = false;
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.4);

            LicniPodaciVM.Init();
        }

        private async void CloseButton_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}