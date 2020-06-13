using System;

namespace HealthCare020.Core.Models
{
    public class UputnicaDtoEL : UputnicaDto
    {
        public PacijentDtoEL Pacijent { get; set; }

        public DoktorDtoEL UputioDoktor { get; set; }

        public DoktorDtoEL UpucenKodDoktora { get; set; }
    }
}