using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class PosetaUpsertDto
    {
        [Required]
        public int PacijentNaLecenjuId { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }

        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get; set; }
    }
}