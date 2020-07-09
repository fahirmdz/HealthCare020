using HealthCare020.Core.Models;
using Healthcare020.Mobile.Resources;

namespace Healthcare020.Mobile
{
    public class DevelopmentTestEntities
    {
        public static PacijentDtoEL GetTestPacijent() => new PacijentDtoEL
        {
            KorisnickiNalogId = 2005,
            Id = 1002,
            Username = "pacijent",
            ZdravstvenaKnjizica = new ZdravstvenaKnjizicaDtoEL
            {
                DoktorId=2,
                Doktor = "Doktor Doktorovic",
                Id=2,
                LicniPodaci = new LicniPodaciDto
                {
                    Adresa = "Gradacacka 40",
                    BrojTelefona = "0622154144",
                    EmailAddress = "pacijent@live.com",
                    Grad = new GradDtoLL
                    {
                        Id = 2,
                        DrzavaId = 12,
                        Naziv = "Sarajevo"
                    },
                    Id = 2,
                    Ime = "Pacijentcic",
                    Prezime = "Pacijentcovic",
                    JMBG = "12323233333",
                    Pol = 'M',
                    ProfilePicture = AppResources.prof
                }
            }
        };
    }
}