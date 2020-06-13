using System;

namespace HealthCare020.Core.ResourceParameters
{
    public class PregledResourceParameters : BaseResourceParameters
    {
        public int? ZahtevZaPregledId { get; set; }

        public int? DoktorId { get; set; }

        public string DoktorIme { get; set; }
        public string DoktorPrezime { get; set; }

        public int? PacijentId { get; set; }

        public string PacijentIme { get; set; }
        public string PacijentPrezime { get; set; }

        public DateTime DatumPregleda { get; set; }
        public bool? IsOdradjen { get; set; } = null;

        public bool EagerLoaded { get; set; } = false;
    }
}