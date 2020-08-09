using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LekarskoUverenjeDialogPage
    {
        public LekarskoUverenjeViewModel LekarskoUverenjeVM { get; set; }
        private int LekarskoUverenjeId;

        public LekarskoUverenjeDialogPage(int lekarskoUverenjeId)
        {
            LekarskoUverenjeId = lekarskoUverenjeId;
            InitializeComponent();
            BindingContext = LekarskoUverenjeVM = ViewModelLocator.LekarskoUverenjeViewModel;
            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            HasKeyboardOffset = false;
            this.BackgroundColor = Color.FromRgba(0, 0, 0, 0.4);
        }

        protected override async void OnAppearing()
        {
            await LekarskoUverenjeVM.Init(LekarskoUverenjeId);
            base.OnAppearing();
        }

        private async void CloseButton_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}