using System;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : BaseValidationContentPage
    {
        public RegisterViewModel RegisterVM;
        private readonly IHud hud;

        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = RegisterVM = new RegisterViewModel(new APIService());

            //Validation requirements
            BaseValidationVM = RegisterVM;
            SetFormBodyElement();
            SetErrorsClearOnTextChanged();

            hud = DependencyService.Get<IHud>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            if(ValidateModel())
                RegisterVM.RegisterCommand.Execute(sender);

        }

        private void CancelButton_OnClicked(object sender, EventArgs e)
        {
            hud.Success("kreiran nalog");

            //Application.Current.MainPage=new WelcomePage();
        }
    }
}