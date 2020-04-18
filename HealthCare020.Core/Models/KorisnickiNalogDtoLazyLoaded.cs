using System.Collections.Generic;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogDtoLazyLoaded:KorisnickiNalogDto
    {
        public ICollection<int> Roles { get; set; }=new List<int>();
    }
}