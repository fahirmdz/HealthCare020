using HealthCare020.Core.ValidationAttributes;
using System;

namespace HealthCare020.Core.Request
{
    public class PregledUpsertDto
    {
        [RequiredWithMessage()]
        public int ZahtevZaPregledId { get; set; }

        [RequiredWithMessage]
        public int PacijentId { get; set; }

        public DateTime DatumPregleda { get; set; }
    }
}