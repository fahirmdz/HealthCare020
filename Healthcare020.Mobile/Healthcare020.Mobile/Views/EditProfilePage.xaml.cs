using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using System;
using HealthCare020.Core.Models;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfilePage
    {
        public EditProfileViewModel EditProfileVM;

        public EditProfilePage()
        {
            Title = AppResources.EditProfilePageTitle;
            InitializeComponent();
            BindingContext = EditProfileVM = ViewModelLocator.EditProfileViewModel;

            //Validation requirements
            BaseValidationVM = EditProfileVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();
        }

        protected override void OnAppearing()
        {
            EditProfileVM.Init();
            base.OnAppearing();
        }

        private void SaveBtn_OnClicked(object sender, EventArgs e)
        {
            if (ValidateModel())
            {
                EditProfileVM.SaveCommand.Execute(sender);
            }
        }
    }
}