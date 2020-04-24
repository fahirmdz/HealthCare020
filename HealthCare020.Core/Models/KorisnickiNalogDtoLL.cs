using System.Collections.Generic;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogDtoLL:KorisnickiNalogDto
    {
        public ICollection<int> Roles { get; set; }=new List<int>();
    }
}