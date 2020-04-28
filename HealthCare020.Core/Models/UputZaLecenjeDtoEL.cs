namespace HealthCare020.Core.Models
{
    public class UputZaLecenjeDtoEL:UputZaLecenjeDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }
        public string Doktor { get; set; }
    }
}