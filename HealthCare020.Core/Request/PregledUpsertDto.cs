using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PregledUpsertDto
    {
        [Required]
        public int ZahtevZaPregledId { get; set; }

        [Required]
        public int PacijentId { get; set; }

        public DateTime DatumPregleda { get; set; }
    }
}