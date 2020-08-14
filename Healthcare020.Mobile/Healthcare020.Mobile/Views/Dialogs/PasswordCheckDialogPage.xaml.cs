using System;
using System.Windows.Input;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordCheckDialogPage
    {
        public ICommand CommandToExecute;
        public PasswordCheckViewModel PasswordCheckVM;

        public PasswordCheckDialogPage(ICommand commandToExecute)
        {
            InitializeComponent();
            BindingContext = PasswordCheckVM = ViewModelLocator.PasswordCheckViewModel;
            CommandToExecute = commandToExecute;

            IsAnimationEnabled = true;
            CloseWhenBackgroundIsClicked = true;
            HasKeyboardOffset = false;
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.4);
        }

        protected override void OnAppearing()
        {
            PasswordCheckVM.Init(CommandToExecute);
            base.OnAppearing();
        }

        private async void SubmitBtn_OnClicked(object sender, EventArgs e)
        {
            await PasswordCheckVM.CheckPassword();
        }
    }
}