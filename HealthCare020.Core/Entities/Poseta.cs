using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Poseta
    {
        public int Id { get; set; }

        [ForeignKey(nameof(PacijentNaLecenju))]
        [Required]
        public int PacijentNaLecenjuId { get; set; }
        public PacijentNaLecenju PacijentNaLecenju { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }

        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get; set; }
    }
}