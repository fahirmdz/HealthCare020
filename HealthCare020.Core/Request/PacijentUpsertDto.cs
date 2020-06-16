using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;

namespace HealthCare020.Core.Request
{
    public class PacijentUpsertDto
    {
        [Required]
        public int BrojZdravstveneKnjizice { get; set; }

        private string _ime;
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Ime { get=>_ime; set=>_ime=value.RemoveWhitespaces(); }

        private string _prezime;
        [StringLength(maximumLength: 15, MinimumLength = 2)]
        public string Prezime { get=>_prezime; set=>_prezime=value.RemoveWhitespaces(); }

        private string _jmbg;
        [StringLength(maximumLength: 12, MinimumLength = 9)]
        public string JMBG { get=>_jmbg; set=>_jmbg=value.RemoveWhitespaces(); }

        [Required]
        public KorisnickiNalogUpsertDto KorisnickiNalog { get; set; }
    }
}