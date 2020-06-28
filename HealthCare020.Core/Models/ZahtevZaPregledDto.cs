using System;

namespace HealthCare020.Core.Models
{
    public abstract class ZahtevZaPregledDto
    {
        public int Id { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumVreme { get; set; }
        public bool IsObradjen { get; set; }
    }
}