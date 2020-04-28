using System;

namespace HealthCare020.Core.Models
{
    public abstract class CustomIzvestajDto
    {
        public int Id { get; set; }

        public double TelesnaTemperatura { get; set; }

        public int KrvniPritisakGornji { get; set; }

        public int KrvniPritisakDonji { get; set; }

        public double GlukozaUKrvi { get; set; }

        public DateTime DatumVreme { get; set; }
    }
}