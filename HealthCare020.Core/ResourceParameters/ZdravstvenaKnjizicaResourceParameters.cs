namespace HealthCare020.Core.ResourceParameters
{
    public class ZdravstvenaKnjizicaResourceParameters:BaseResourceParameters
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? DoktorId { get; set; }
        public string DoktorIme { get; set; }
        public string DoktorPrezime { get; set; }

        public bool EagerLoaded { get; set; } = false;
    }
}