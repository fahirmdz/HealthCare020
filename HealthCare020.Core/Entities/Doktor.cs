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

        public virtual ICollection<UputZaLecenje> UputiZaLecenje { get; set; }
        public virtual string ImePrezime => Radnik.LicniPodaci.Ime + " " + Radnik.LicniPodaci.Prezime;

        public virtual ICollection<DnevniIzvestaj> DnevniIzvestaji { get; set; }
    }
}