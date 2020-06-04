using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class ZahtevZaPregled
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Pacijent))]
        [Required]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey(nameof(Doktor))]
        [Required]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        [ForeignKey(nameof(Uputnica))]
        public int? UputnicaId { get; set; }
        public Uputnica Uputnica { get; set; }

        [StringLength(255,ErrorMessage = "Maximum length is 255 characters",MinimumLength = 5)]
        [Required]
        public string Napomena { get; set; }
    }
}