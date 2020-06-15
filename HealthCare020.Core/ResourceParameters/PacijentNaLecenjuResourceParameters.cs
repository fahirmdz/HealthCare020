namespace HealthCare020.Core.ResourceParameters
{
    public class PacijentNaLecenjuResourceParameters:BaseResourceParameters
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? StacionarnoOdeljenjeId { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}