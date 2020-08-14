using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using System;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage
    {
        public ChangePasswordViewModel ChangePasswordVM;

        public ChangePasswordPage()
        {
            InitializeComponent();
            Title = AppResources.ChangePasswordPageTitle;
            BindingContext = ChangePasswordVM = ViewModelLocator.ChangePasswordViewModel;
            IconImageSource = IconFont.Key.GetIcon();
            //Validation requirements
            BaseValidationVM = ChangePasswordVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();
        }

        protected override void OnAppearing()
        {
            ChangePasswordVM.Init();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
        }

        private void ChangePasswordBtn_OnClicked(object sender, EventArgs e)
        {
            if (ValidateModel())
            {
                ChangePasswordVM.ChangePasswordCommand.Execute(sender);
            }
        }
    }
}