using System;

namespace HealthCare020.Core.Models
{
    public abstract class DnevniIzvestajDto
    {
        public int Id { get; set; }

        public string OpisStanja { get; set; }

        public DateTime DatumVreme { get; set; }

        public int ZdravstvenoStanjeId { get; set; }

        public int DoktorId { get; set; }

        public int PacijentId { get; set; }
    }
}