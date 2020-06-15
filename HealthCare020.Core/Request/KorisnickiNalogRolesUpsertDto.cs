using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogRolesUpsertDto
    {
        [Required]
        public int RoleId;
    }
}