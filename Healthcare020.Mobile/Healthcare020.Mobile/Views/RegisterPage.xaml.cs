using System;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : BaseValidationContentPage
    {
        public RegisterViewModel RegisterVM;

        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = RegisterVM = new RegisterViewModel();

            //Validation requirements
            BaseValidationVM = RegisterVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            ValidateModel();
        }
    }
}