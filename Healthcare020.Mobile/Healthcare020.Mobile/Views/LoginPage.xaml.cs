using System;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel LoginVM;
        public LoginPage()
        {
            InitializeComponent();
            LoginVM = (LoginViewModel) this.BindingContext;
        }


        private void RememberMe_OnToggled(object sender, ToggledEventArgs e)=> LoginVM.RememberMe = RememberMe.IsToggled;

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var username = Username.Text;
            var password = Password.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                UsernameErrorLabel.Text = "Obavezno polje";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                UsernameErrorLabel.Text = "Obavezno polje";
                return;
            }

            LoginVM.LoginCommand.Execute(sender);
        }
    }
}