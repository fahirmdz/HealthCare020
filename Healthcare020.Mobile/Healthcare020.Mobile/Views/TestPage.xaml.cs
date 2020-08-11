using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Healthcare020.Mobile.Constants;
using Healthcare020.Mobile.Helpers;
using Healthcare020.Mobile.Interfaces;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.Services;
using Healthcare020.Mobile.ViewModels;
using Healthcare020.Mobile.Views.Dialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestViewModel TestVM;

        public TestPage()
        {
            InitializeComponent();
            BindingContext = TestVM=new TestViewModel();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }


    }
}