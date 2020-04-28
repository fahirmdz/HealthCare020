using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class UputZaLecenje
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 250, MinimumLength = 5)]
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        public string OpisStanja { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public DateTime DatumVreme { get; set; } = DateTime.Now;

        [ForeignKey(nameof(LicniPodaci))]
        public int LicniPodaciId { get; set; }
        public LicniPodaci LicniPodaci { get; set; }

        [ForeignKey(nameof(Doktor))]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

    }
}