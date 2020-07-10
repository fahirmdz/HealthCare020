using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare020.Mobile.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreglediMainPage : ContentPage
    {
        public PreglediMainPage()
        {
            Title = AppResources.PreglediTabTitle;
            InitializeComponent();
        }
    }
}