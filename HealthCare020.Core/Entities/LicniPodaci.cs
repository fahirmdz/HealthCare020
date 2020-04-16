using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare020.Core.Entities
{
    public class LicniPodaci
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 15, MinimumLength = 2)]//
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength:12,MinimumLength = 9)]
        public string JMBG { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Adresa { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [DefaultValue("M")]
        public char Pol { get; set; }

        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}