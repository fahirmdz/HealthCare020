using System;

namespace HealthCare020.Core.Models
{
    public abstract class UputnicaDto
    {
        public int Id { get; set; }

        public string Razlog { get; set; }

        public string Napomena { get; set; }

        public DateTime DatumVreme { get; set; }
    }
}