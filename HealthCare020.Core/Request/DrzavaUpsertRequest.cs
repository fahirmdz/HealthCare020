using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class DrzavaUpsertRequest
    {
        private string _naziv;

        [RequiredWithMessage]
        [StringLengthWithMessage(2, 30)]
        [DataType(DataType.Text)]
        public string Naziv { get => _naziv; set => _naziv = value.RemoveWhitespaces(); }

        private string _pozivniBroj;

        [RequiredWithMessage]
        [StringLengthWithMessage(2, 5)]
        public string PozivniBroj { get => _pozivniBroj; set => _pozivniBroj = value.RemoveWhitespaces(); }
    }
}