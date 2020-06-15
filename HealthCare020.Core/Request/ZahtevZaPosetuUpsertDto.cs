using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPosetuUpsertDto
    {
        [Required]
        public int PacijentNaLecenjuId { get; set; }

        [Required]
        [FutureDateTime(ErrorMessage = "Datum i vrijeme posete moraju biti u buducnosti")]
        public DateTime DatumVreme { get; set; }

        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get; set; }
    }
}