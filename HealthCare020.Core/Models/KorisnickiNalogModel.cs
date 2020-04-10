using System;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LastOnline { get; set; }
        public DateTime DateCreated { get; set; }
    }
}