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
    public partial class ZahteviZaPregledMainPage : ContentPage
    {
        private ZahteviZaPregledViewModel ZahteviZaPregledVM;

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
            //ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            //{
            //    Id = 1,
            //    DatumVreme = DateTime.Now.AddDays(15),
            //    Doktor = "Doktor Doktorovic",
            //    IsObradjen = true,
            //    Napomena = "Napomena neka velika",
            //    Pacijent = new PacijentDtoEL
            //    {
            //        Id = 1,
            //        KorisnickiNalogId = 1,
            //        Username = "test",
            //        ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
            //        {
            //            Doktor = "Doktor Doktorovic",
            //            DoktorId = 1,
            //            Id = 1,
            //            LicniPodaci = new LicniPodaciDto
            //            {
            //                Adresa = "Test adresa",
            //                Ime = "Pacijentime",
            //                Prezime = "Pacijentprezime"
            //            }
            //        }
            //    }
            //});

            //ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            //{
            //    Id = 1,
            //    DatumVreme = DateTime.Now.AddDays(10),
            //    Doktor = "Doktor Doktorovic",
            //    IsObradjen = true,
            //    Napomena = "Napomena neka velika",
            //    Pacijent = new PacijentDtoEL
            //    {
            //        Id = 1,
            //        KorisnickiNalogId = 1,
            //        Username = "test",
            //        ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
            //        {
            //            Doktor = "Doktor Doktorovic",
            //            DoktorId = 1,
            //            Id = 1,
            //            LicniPodaci = new LicniPodaciDto
            //            {
            //                Adresa = "Test adresa",
            //                Ime = "Pacijentime",
            //                Prezime = "Pacijentprezime"
            //            }
            //        }
            //    }
            //});

            //ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            //{
            //    Id = 1,
            //    DatumVreme = DateTime.Now,
            //    Doktor = "Doktor Doktorovic",
            //    IsObradjen = true,
            //    Napomena = "Napomena neka velika",
            //    Pacijent = new PacijentDtoEL
            //    {
            //        Id = 1,
            //        KorisnickiNalogId = 1,
            //        Username = "test",
            //        ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
            //        {
            //            Doktor = "Doktor Doktorovic",
            //            DoktorId = 1,
            //            Id = 1,
            //            LicniPodaci = new LicniPodaciDto
            //            {
            //                Adresa = "Test adresa",
            //                Ime = "Pacijentime",
            //                Prezime = "Pacijentprezime"
            //            }
            //        }
            //    }
            //});
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