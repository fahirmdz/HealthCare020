using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogUpsertDto
    {
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength: 20, MinimumLength = 4,ErrorMessage="Username mora sadrzati izmedju 4 i 20 karaktera")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [StringLength(maximumLength:int.MaxValue,MinimumLength = 6,ErrorMessage = "Lozinka mora sadrzati minimalno 6 karaktera")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Obavezno polje",AllowEmptyStrings = false)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public bool LockedOut { get; set; } = false;
        public DateTime? LokedOutUntil { get; set; }

        [MaxLength(4,ErrorMessage = "Maximum number of roles is 4 per one request")]
        public ICollection<int> Roles { get; set; }=new List<int>();

        [MaxLength(4,ErrorMessage = "Maximum number of roles is 4 per one request")]
        public ICollection<int> RolesToDelete { get; set; }=new List<int>();
    }
}