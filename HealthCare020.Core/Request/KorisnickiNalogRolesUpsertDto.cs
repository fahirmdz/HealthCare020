using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class KorisnickiNalogRolesUpsertDto
    {
        [MaxLength(2,ErrorMessage = "Maximum number of roles is 2 per one request")]
        public ICollection<int> Roles { get; set; }=new List<int>();
    }
}