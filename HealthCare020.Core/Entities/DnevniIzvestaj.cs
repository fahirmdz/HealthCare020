using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class DnevniIzvestaj
    {
        public int Id { get; set; }
        
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        public string OpisStanja { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        public DateTime DatumVreme { get; set; }

        [ForeignKey(nameof(ZdravstvenoStanje))]
        public int ZdravstvenoStanjeId { get; set; }
        public ZdravstvenoStanje ZdravstvenoStanje { get; set; }

        [ForeignKey(nameof(Doktor))]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        [ForeignKey(nameof(Pacijent))]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}