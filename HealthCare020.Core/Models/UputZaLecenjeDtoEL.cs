namespace HealthCare020.Core.Models
{
    public class UputZaLecenjeDtoEL:UputZaLecenjeDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }
        public DoktorDtoEL Doktor { get; set; }
    }
}