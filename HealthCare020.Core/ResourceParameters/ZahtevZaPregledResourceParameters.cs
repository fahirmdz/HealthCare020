namespace HealthCare020.Core.ResourceParameters
{
    public class ZahtevZaPregledResourceParameters:BaseResourceParameters
    {
        public int? PacijentId { get; set; }
        public string PacijentIme { get; set; }
        public string PacijentPrezime { get; set; }

        public int? DoktorId { get; set; }
        public string DoktorIme{ get; set; }
        public string DoktorPrezime{ get; set; }

        public int? UputnicaId { get; set; }

        public string Napomena { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}