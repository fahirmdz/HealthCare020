﻿using System;

namespace HealthCare020.Core.Models
{
    public class KorisnickiNalogDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string LastOnline { get; set; }
        public string DateCreated { get; set; }
        public bool LockedOut { get; set; } = false;
        public DateTime? LockedOutUntil { get; set; }
    }
}