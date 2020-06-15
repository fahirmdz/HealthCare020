namespace HealthCare020.Core.Models
{
    public class PacijentNaLecenjuDtoEL:PacijentNaLecenjuDto
    {
        public LicniPodaciDto LicniPodaci { get; set; }
        public TwoFieldsDto StacionarnoOdeljenje { get; set; }
    }
}