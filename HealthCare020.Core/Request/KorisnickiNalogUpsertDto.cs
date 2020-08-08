using System.ComponentModel.DataAnnotations;
using HealthCare020.Core.Extensions;
using HealthCare020.Core.ValidationAttributes;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogUpsertDto
    {
        private string _username;
        [RequiredWithMessage]
        [StringLengthWithMessage(4,20)]
        public string Username { get=>_username; set=>_username=value.RemoveWhitespaces(); }

        [DataType(DataType.Password)]
        [RequiredWithMessage]
        [StringLengthWithMessage(6,int.MaxValue)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [RequiredWithMessage]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string RoleType { get; set; } = string.Empty;
    }
}