using System;
using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class UputnicaUpsertDto
    {
        [Required]
        public int PacijentId { get; set; }

        [Required]
        public int UpucenKodDoktoraId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Razlog { get; set; }

        [MaxLength(255)]
        public string Napomena { get; set; }

        [Required]
        [FutureDateTime]
        public DateTime DatumVreme { get; set; }
    }
}