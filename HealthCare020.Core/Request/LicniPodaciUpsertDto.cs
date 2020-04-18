using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class LicniPodaciUpsertDto
    {
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength:12,MinimumLength = 9)]
        public string JMBG { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [DefaultValue("M")]
        public char Pol { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        public int GradId { get; set; }
    }
}