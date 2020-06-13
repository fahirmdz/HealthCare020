using System;

namespace HealthCare020.Core.ResourceParameters
{
    public class PosetaResourceParameters : BaseResourceParameters
    {
        public string PacijentImePrezime { get; set; }
        public DateTime DatumVreme { get; set; }
        public string BrojTelefonaPosetioca { get; set; }
        public bool EagerLoaded { get; set; } = false;
    }
}