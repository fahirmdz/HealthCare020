using System;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime DateCreated { get; set; }
    }
}