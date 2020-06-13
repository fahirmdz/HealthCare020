namespace HealthCare020.Core.ResourceParameters
{
    public class ZahtevZaPregledResourceParameters:BaseResourceParameters
    {
        public int? PacijentId { get; set; }
        public string PacijentImePrezime { get; set; }

        public int? DoktorId { get; set; }
        public string DoktorImePrezime { get; set; }

        public int? UputnicaId { get; set; }

        public string Napomena { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}