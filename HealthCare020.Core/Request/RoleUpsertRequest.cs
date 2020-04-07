﻿using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Request
{
    public class RoleUpsertRequest
    {
        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(maximumLength:15,MinimumLength = 3,ErrorMessage = "Naziv role mora sadrzati izmedju 3 i 15 slova")]
        public string Naziv { get; set; }
    }
}