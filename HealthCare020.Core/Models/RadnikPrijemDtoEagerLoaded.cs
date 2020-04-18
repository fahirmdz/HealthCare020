using System;

namespace HealthCare020.Core.Models
{
    public class RadnikPrijemDtoEagerLoaded
    {
        public int Id { get; set; }
        //Korisnicki nalog

        public int KorisnickiNalogId { get; set; }
        public string Username { get; set; }

        //Licni podaci
        public int LicniPodaciId { get; set; }
        public string ImePrezime { get; set; }
        public string JMBG { get; set; }

        public string Adresa { get; set; }

        public char Pol { get; set; }

        public string BrojTelefona { get; set; }

        public string Grad { get; set; }

        public int StacionarnoOdeljenjeId { get; set; }
        public string StacionarnoOdeljenje { get; set; }
    }
}