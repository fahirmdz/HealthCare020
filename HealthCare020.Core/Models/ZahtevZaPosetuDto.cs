using System;

namespace HealthCare020.Core.Models
{
    public abstract class ZahtevZaPosetuDto
    {
        public int Id { get; set; }
        public DateTime DatumVremeKreiranja { get; set; }

        public DateTime? ZakazanoDatumVreme { get; set; }
        public bool IsObradjen { get; set; }

        public string BrojTelefonaPosetioca { get; set; }
    }
}