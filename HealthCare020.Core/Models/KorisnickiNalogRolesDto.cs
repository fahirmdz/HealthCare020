using System.Collections.Generic;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogRolesDto
    {
        public ICollection<TwoFieldsDto> Roles { get; set; } = new List<TwoFieldsDto>();
    }
}