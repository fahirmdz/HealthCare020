namespace HealthCare020.Core.Request
{
    public abstract class RadnikUpsertDto
    {
        public LicniPodaciUpsertDto LicniPodaci { get; set; }
        public KorisnickiNalogUpsertDto KorisnickiNalog { get; set; }
        public int StacionarnoOdeljenjeId { get; set; } 
    }
}