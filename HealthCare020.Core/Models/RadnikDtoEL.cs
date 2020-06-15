namespace HealthCare020.Core.Models
{
    public class RadnikDtoEL
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TwoFieldsDto StacionarnoOdeljenje { get; set; }
        public int LicniPodaciId { get; set; }
    }
}