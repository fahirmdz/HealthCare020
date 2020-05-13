using System.Collections.Generic;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogDtoEL : KorisnickiNalogDto
    {
        public List<TwoFieldsDto> Roles { get; set; }
    }
}