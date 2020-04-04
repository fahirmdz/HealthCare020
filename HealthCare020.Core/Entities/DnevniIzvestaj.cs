using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class DnevniIzvestaj
    {
        public int Id { get; set; }
        
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        [Required]
        public string OpisStanja { get; set; }

        [Required]
        public DateTime DatumVreme { get; set; }

        [ForeignKey(nameof(ZdravstvenoStanje))]
        public int ZdravstvenoStanjeId { get; set; }
        public ZdravstvenoStanje ZdravstvenoStanje { get; set; }

        [ForeignKey(nameof(MedicinskiTehnicar))]
        public int MedicinskiTehnicarId { get; set; }
        public MedicinskiTehnicar MedicinskiTehnicar { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}