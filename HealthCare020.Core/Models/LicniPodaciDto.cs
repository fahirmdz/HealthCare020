namespace HealthCare020.Core.Models
{
    public class LicniPodaciDto
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }
        public string JMBG { get; set; }

        public string Adresa { get; set; }

        public char Pol { get; set; }

        public string BrojTelefona { get; set; }

        public GradDto Grad { get; set; }
    }
}