using HealthCare020.Core.Extensions;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class ZahtevZaPosetuUpsertDto
    {
        [Required]
        public int PacijentNaLecenjuId { get; set; }

        private string _brojTelefona;
        [Phone]
        [Required]
        public string BrojTelefonaPosetioca { get => _brojTelefona; set => _brojTelefona = value.RemoveWhitespaces(); }
    }
}