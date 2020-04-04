using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class LicniPodaci
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Ime { get; set; }

        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Adresa { get; set; }

        [Required]
        [DefaultValue("M")]
        public char Pol { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}