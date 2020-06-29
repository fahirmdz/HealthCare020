using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Uputnica
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Pacijent))]
        [Required]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey(nameof(UputioDoktor))]
        [Required]
        public int UputioDoktorId { get; set; }
        public Doktor UputioDoktor { get; set; }

        [ForeignKey(nameof(UpucenKodDoktora))]
        [Required]
        public int UpucenKodDoktoraId { get; set; }
        public Doktor UpucenKodDoktora { get; set; }

        [Required]
        public string Razlog { get; set; }

        public string Napomena { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }
    }
}