namespace HealthCare020.Core.Models
{
    public class RadnikDto
    {
        public int Id { get; set; }
        public LicniPodaciDto LicniPodaci { get; set; }

        public KorisnickiNalogDto KorisnickiNalog { get; set; }

        public TwoFieldsDto StacionarnoOdeljenje { get; set; }
    }
}