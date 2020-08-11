using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using HealthCare020.Core.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PosetaPage : BaseValidationContentPage
    {
        private PosetaViewModel PosetaVM;

        public PosetaPage()
        {
            InitializeComponent();

            BindingContext = PosetaVM = ViewModelLocator.PosetaViewModel;

            //Validation requirements
            BaseValidationVM = PosetaVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();
        }

        protected override async void OnAppearing()
        {
            await PosetaVM.Init();
            base.OnAppearing();
        }

        private void SearchButton_OnClicked(object sender, EventArgs e)
        {
            PosetaVM.SearchPacijentiCommand.Execute(sender);
        }

        private void PacijentPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is Picker picker)
            {
                if (picker.SelectedIndex == -1)
                {
                    BrojTelefonaPosetioca.IsVisible = false;
                    ConfirmButton.IsVisible = false;
                }
                else
                {
                    PosetaVM.PacijentPicked = picker.SelectedItem as PacijentNaLecenjuDtoEL;
                    BrojTelefonaPosetioca.IsVisible = true;
                    ConfirmButton.IsVisible = true;
                }
            }
        }

        private void ConfirmButton_OnClicked(object sender, EventArgs e)
        {
            if (ValidateModel())
                PosetaVM.CreatePosetaCommand.Execute(sender);
        }
    }
}