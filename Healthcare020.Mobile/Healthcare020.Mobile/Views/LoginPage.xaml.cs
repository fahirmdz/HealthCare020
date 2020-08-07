using Healthcare020.Mobile.ViewModels;
using System;
using Healthcare020.Mobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : BaseValidationContentPage
    {
        private LoginViewModel LoginVM;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = LoginVM = ViewModelLocator.LoginViewModel;

            //Validation requirements
            BaseValidationVM = LoginVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void RememberMe_OnToggled(object sender, ToggledEventArgs e) => LoginVM.RememberMe = RememberMe.IsToggled;

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (ValidateModel())
                LoginVM.LoginCommand.Execute(sender);
        }

        private void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private void FaceIDLogin_OnClicked(object sender, EventArgs e)
        {
            LoginVM.FaceIDLoginCommand.Execute(sender);

        }
    }
}