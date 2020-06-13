using System;

namespace HealthCare020.Core.Request
{
    public class PregledUpsertDto
    {
        public int ZahtevZaPregledId { get; set; }

        public int DoktorId { get; set; }

        public int PacijentId { get; set; }

        public DateTime DatumPregleda { get; set; }
    }
}