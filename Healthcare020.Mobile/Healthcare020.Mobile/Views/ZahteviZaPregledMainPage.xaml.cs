using System;
using HealthCare020.Core.Models;
using Healthcare020.Mobile.Resources;
using Healthcare020.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Healthcare020.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZahteviZaPregledMainPage : ContentPage
    {
        private ZahteviZaPregledViewModel ZahteviZaPregledVM;
        public ZahteviZaPregledMainPage()
        {
            Title = AppResources.ZahteviTabTitle;
            BindingContext = ZahteviZaPregledVM = new ZahteviZaPregledViewModel();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await ZahteviZaPregledVM.Init();
            ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            {
                Id=1,
                DatumVreme = DateTime.Now.AddDays(15),
                Doktor = "Doktor Doktorovic",
                IsObradjen = true,
                Napomena = "Napomena neka velika",
                Pacijent = new PacijentDtoEL
                {
                    Id=1,
                    KorisnickiNalogId = 1,
                    Username = "test",
                    ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
                    {
                        Doktor= "Doktor Doktorovic",
                        DoktorId = 1,
                        Id = 1,
                        LicniPodaci = new LicniPodaciDto
                        {
                            Adresa = "Test adresa",
                            Ime = "Pacijentime",
                            Prezime = "Pacijentprezime"
                        }
                    }
                }
            });

            ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            {
                Id = 1,
                DatumVreme = DateTime.Now.AddDays(10),
                Doktor = "Doktor Doktorovic",
                IsObradjen = true,
                Napomena = "Napomena neka velika",
                Pacijent = new PacijentDtoEL
                {
                    Id = 1,
                    KorisnickiNalogId = 1,
                    Username = "test",
                    ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
                    {
                        Doktor = "Doktor Doktorovic",
                        DoktorId = 1,
                        Id = 1,
                        LicniPodaci = new LicniPodaciDto
                        {
                            Adresa = "Test adresa",
                            Ime = "Pacijentime",
                            Prezime = "Pacijentprezime"
                        }
                    }
                }
            });

            ZahteviZaPregledVM.ZahteviZaPregled.Add(new ZahtevZaPregledDtoEL
            {
                Id = 1,
                DatumVreme = DateTime.Now,
                Doktor = "Doktor Doktorovic",
                IsObradjen = true,
                Napomena = "Napomena neka velika",
                Pacijent = new PacijentDtoEL
                {
                    Id = 1,
                    KorisnickiNalogId = 1,
                    Username = "test",
                    ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
                    {
                        Doktor = "Doktor Doktorovic",
                        DoktorId = 1,
                        Id = 1,
                        LicniPodaci = new LicniPodaciDto
                        {
                            Adresa = "Test adresa",
                            Ime = "Pacijentime",
                            Prezime = "Pacijentprezime"
                        }
                    }
                }
            });
        }
    }
}