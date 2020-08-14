using System;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoviZahtevZaPregledPage
    {
        private readonly NoviZahtevZaPregledViewModel NoviZahtevZaPregledVM;

        public NoviZahtevZaPregledPage()
        {
            InitializeComponent();
            Title = AppResources.NoviZahtevZaPregledPageTitle;

            BindingContext = NoviZahtevZaPregledVM = ViewModelLocator.NoviZahtevZaPregledViewModel;

            //Validation requirements
            BaseValidationVM = NoviZahtevZaPregledVM;
            SetFormBodyElement();
            SetErrorsClearOnPickerFocused();
        }

        protected override async void OnAppearing()
        {
            await NoviZahtevZaPregledVM.Init();
        }

        private void ProslediButton_OnClicked(object sender, EventArgs e)
        {
            if (ValidateModel())
                NoviZahtevZaPregledVM.SaveCommand.Execute(sender);
        }
    }
}