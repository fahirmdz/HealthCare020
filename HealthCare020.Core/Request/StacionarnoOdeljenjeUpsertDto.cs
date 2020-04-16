using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class StacionarnoOdeljenjeUpsertDto
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength:40,MinimumLength = 4,ErrorMessage="Naziv stacionarnog odeljenja mora sadrzati izmedju od 4 do 40 slova")]
        public string Naziv { get; set; }
    }
}