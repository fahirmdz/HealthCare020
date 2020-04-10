using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogRoleUpsertRequest
    {
        [Required(ErrorMessage="Obavezno polje")]
        public int RoleId { get; set; }

        [Required(ErrorMessage="Obavezno polje")]
        public int KorisnickiNalogId { get; set; }
    }
}