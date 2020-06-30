using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class ZahtevZaPosetu
    {
        public int Id { get; set; }

        [ForeignKey(nameof(PacijentNaLecenju))]
        [Required]
        public int PacijentNaLecenjuId { get; set; }
        public PacijentNaLecenju PacijentNaLecenju { get; set; }

        [Required]
        public DateTime DatumVremeKreiranja { get; set; }

        public DateTime? ZakazanoDatumVreme { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsObradjen { get; set; }

        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get; set; }
    }
}