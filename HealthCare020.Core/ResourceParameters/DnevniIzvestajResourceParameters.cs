namespace HealthCare020.Core.ResourceParameters
{
    public class DnevniIzvestajResourceParameters:BaseResourceParameters
    {
        public bool EagerLoaded { get; set; } = false;
        public string Opis { get; set; }
        public int? PacijentId { get; set; }
        public string PacijentIme { get; set; }
        public string PacijentPrezime { get; set; }
        public int? DoktorId { get; set; }
        public string DoktorIme { get; set; }
        public string DoktorPrezime { get; set; }
        public string ZdravstvenoStanje { get; set; }
        public string Datum { get; set; }
    }
}