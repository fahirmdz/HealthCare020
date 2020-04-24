namespace HealthCare020.Core.Models
{
    public abstract class RadnikDtoEL
    {
        public KorisnickiNalogDtoEL KorisnickiNalog { get; set; }
        public LicniPodaciDto LicniPodaci { get; set; }
        public TwoFieldsDto StacionarnoOdeljenje { get; set; }
    }
}