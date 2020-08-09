using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PregledDialogPage : IDisposable
    {
        public PregledViewModel PregledVM { get; set; }
        private int PregledId;

        public PregledDialogPage(int pregledId)
        {
            PregledId = pregledId;
            InitializeComponent();
            BindingContext = PregledVM = ViewModelLocator.PregledViewModel;

            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            HasKeyboardOffset = false;
            this.BackgroundColor = Color.FromRgba(0, 0, 0, 0.4);

            LekarskoUverenjeButton.Clicked += (sender, e) =>
            {
                PregledVM.LekarskoUverenjeCommand.Execute(sender);
            };
        }

        protected override async void OnAppearing()
        {
            await PregledVM.Init(PregledId);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void CloseButton_OnClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        public void Dispose()
        {
            this.Dispose();
        }

    }
}