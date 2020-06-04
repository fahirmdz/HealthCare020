using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Doktor
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Radnik))]
        public int RadnikId { get; set; }
        public Radnik Radnik { get; set; }

        [ForeignKey(nameof(NaucnaOblast))]
        public int NaucnaOblastId { get; set; }
        public NaucnaOblast NaucnaOblast { get; set; }

        public ICollection<ZahtevZaPregled> ZahteviZaPregled { get; set; }
        public ICollection<Pregled> Pregledi { get; set; }
        public ICollection<Uputnica> UputniceUputio { get; set; }
        public ICollection<Uputnica> UputnicePrimio { get; set; }
        public ICollection<LekarskoUverenje> LekarskaUverenja { get; set; }
    }
}