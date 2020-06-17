using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogUpsertDto
    {
        private string _username;
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Username mora sadrzati izmedju 4 i 20 karaktera")]
        public string Username { get=>_username; set=>_username=value.RemoveWhitespaces(); }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [StringLength(maximumLength: int.MaxValue, MinimumLength = 6, ErrorMessage = "Lozinka mora sadrzati minimalno 6 karaktera")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Obavezno polje", AllowEmptyStrings = false)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string RoleType { get; set; } = string.Empty;
    }
}