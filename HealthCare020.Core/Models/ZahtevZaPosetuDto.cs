using System;

namespace HealthCare020.Core.Models
{
    public abstract class ZahtevZaPosetuDto
    {
        public int Id { get; set; }

        public DateTime DatumVreme { get; set; }

        public string BrojTelefonaPosetioca { get; set; }
    }
}