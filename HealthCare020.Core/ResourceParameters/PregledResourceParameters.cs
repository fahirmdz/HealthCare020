using System;

namespace HealthCare020.Core.ResourceParameters
{
    public class PregledResourceParameters : BaseResourceParameters
    {
        public int? ZahtevZaPregledId { get; set; }

        public int? DoktorId { get; set; }

        public string DoktorImePrezime { get; set; }

        public int? PacijentId { get; set; }

        public string PacijentImePrezime { get; set; }

        public DateTime DatumPregleda { get; set; }
        public bool IsOdradjen { get; set; }
    }
}