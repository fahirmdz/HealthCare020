using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZahteviZaPregledMainPage
    {
        private readonly ZahteviZaPregledViewModel ZahteviZaPregledVM;

        private Expander LastExpandedExpander;

        public ZahteviZaPregledMainPage()
        {
            Title = AppResources.ZahteviTabTitle;
            BindingContext = ZahteviZaPregledVM = new ZahteviZaPregledViewModel();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ZahteviZaPregledVM.Init();
        }

        private async void CollectionItem_OnTapped(object sender, EventArgs e)
        {
            var grid = (Grid)sender;

            var DateStack = grid.Children.OfType<StackLayout>().FirstOrDefault(x => x.ClassId == "LabelsToScaleStack");
            if (DateStack == null)
                return;

            if (DateStack.Scale - 1 <= 0.1)
                await DateStack.ScaleTo(1.1, 200);
            else
                await DateStack.ScaleTo(1, 200);
        }

        private void SearchEntry_OnCompleted(object sender, EventArgs e)
        {
            ZahteviZaPregledVM.SearchCommand.Execute(sender);
        }

        private async void Expander_OnTapped(object sender, EventArgs e)
        {
            var expander = (Expander)sender;

            //Close other expanders
            if (expander.IsExpanded)
            {
                if (LastExpandedExpander != null && LastExpandedExpander != expander)
                    LastExpandedExpander.IsExpanded = false;
                LastExpandedExpander = expander;
            }

            //Hide navigation buttons if one expander is expanded
            if (expander.IsExpanded)
                PrevNextNavigations.IsVisible = false;
            else
            {
                await Task.Delay(300);
                PrevNextNavigations.Opacity = 0;
                PrevNextNavigations.IsVisible = true;
                await PrevNextNavigations.FadeTo(1, 400);
            }
        }
    }
}