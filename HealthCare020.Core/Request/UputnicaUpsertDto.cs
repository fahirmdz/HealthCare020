using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class UputnicaUpsertDto
    {
        [Required]
        public int PacijentId { get; set; }

        [Required]
        public int UputioDoktorId { get; set; }

        [Required]
        public int UpucenKodDoktoraId { get; set; }

        [Required]
        public string Razlog { get; set; }

        [Required]
        public string Napomena { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }
    }
}