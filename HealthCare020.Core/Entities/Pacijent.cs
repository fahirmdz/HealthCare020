using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class Pacijent
    {
        public int Id { get; set; }

        [ForeignKey(nameof(LicniPodaci))]
        public int LicniPodaciId { get; set; }
        public LicniPodaci LicniPodaci { get; set; }

        public virtual ICollection<CustomIzvestaj> CustomIzvestaji { get; set; }
        public virtual ICollection<DnevniIzvestaj> DnevniIzvestaji { get; set; }
        public virtual ICollection<Poseta> Posete { get; set; }
    }
}