using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare020.Core.Entities
{
    public class KorisnickiNalog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 4)]
        public string Username { get; set; }

        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime DateCreated { get; set; }
    }
}