using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class ZdravstvenaKnjizica
    {
        public int Id { get; set; }

        [ForeignKey(nameof(LicniPodaci))]
        public int LicniPodaciId { get; set; }
        public LicniPodaci LicniPodaci { get; set; }

        [ForeignKey(nameof(Doktor))]
        [Required]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}