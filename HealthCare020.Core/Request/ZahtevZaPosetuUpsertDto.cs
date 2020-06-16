using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
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

        private string _brojTelefona;
        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get=>_brojTelefona; set=>_brojTelefona=value.RemoveWhitespaces(); }
    }
}