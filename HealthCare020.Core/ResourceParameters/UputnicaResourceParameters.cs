using System;

namespace HealthCare020.Core.ResourceParameters
{
    public class UputnicaResourceParameters : BaseResourceParameters
    {
        public int? PacijentId { get; set; }
        public string PacijentImePrezime { get; set; }

        public int? UputioDoktorId { get; set; }
        public string UputioDoktorImePrezime { get; set; }

        public int? UpucenKodDoktoraId { get; set; }
        public string UpucenKodDoktoraImePrezime { get; set; }

        public string Razlog { get; set; }

        public string Napomena { get; set; }

        public DateTime DatumVreme { get; set; }

        public bool EagerLoaded { get; set; } = false;
    }
}