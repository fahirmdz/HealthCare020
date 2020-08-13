using System;

namespace HealthCare020.Core.Models
{
    public class LicniPodaciDto
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string JMBG { get; set; }
        public string Adresa { get; set; }
        public char Pol { get; set; }
        public string EmailAddress { get; set; }
        public string BrojTelefona { get; set; }

        public GradDtoLL Grad { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string ImePrezime => $"{Ime} {Prezime}";

        public LicniPodaciDto()
        {
        }


        public LicniPodaciDto(LicniPodaciDto licniPodaci)
        {
            Id = licniPodaci.Id;
            Ime = licniPodaci.Ime;
            Prezime = licniPodaci.Prezime;
            JMBG = licniPodaci.JMBG;
            Adresa = licniPodaci.Adresa;
            Pol = licniPodaci.Pol;
            EmailAddress = licniPodaci.EmailAddress;
            BrojTelefona = licniPodaci.BrojTelefona;
            Grad = new GradDtoLL(licniPodaci.Grad);
            ProfilePicture = licniPodaci.ProfilePicture;
        }
    }
}