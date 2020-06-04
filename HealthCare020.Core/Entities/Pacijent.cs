using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Pacijent
    {
        public int Id { get; set; }

        [ForeignKey(nameof(ZdravstvenaKnjizica))]
        [Required]
        public int ZdravstvenaKnjizicaId { get; set; }
        public ZdravstvenaKnjizica ZdravstvenaKnjizica { get; set; }

        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }

        public ICollection<ZahtevZaPregled> ZahteviZaPregled { get; set; }
        public ICollection<Pregled> Pregledi { get; set; }
        public ICollection<Uputnica> Uputnice { get; set; }
    }
}