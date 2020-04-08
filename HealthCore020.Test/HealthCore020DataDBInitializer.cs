using HealthCare020.Core.Entities;
using HealthCare020.Repository;
using System;

namespace HealthCore020.Test
{
    public class HealthCore020DataDBInitializer
    {
        public HealthCore020DataDBInitializer()
        {
        }

        public void Seed_ZdravstvenoStanje(HealthCare020DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.ZdravstvenaStanja.AddRange(
                new ZdravstvenoStanje { Opis = "TestOpis1" },
                new ZdravstvenoStanje { Opis = "TestOpis2" },
                new ZdravstvenoStanje { Opis = "TestOpis3" },
                new ZdravstvenoStanje { Opis = "TestOpis4" },
                new ZdravstvenoStanje { Opis = "TestOpis5" },
                new ZdravstvenoStanje { Opis = "TestOpis6" }
            );

            context.SaveChanges();
        }

        public void Seed_Korisnik(HealthCare020DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.KorisnickiNalozi.AddRange(
                new KorisnickiNalog
                {
                    DateCreated = new DateTime(2018, 1, 1),
                    LastOnline = new DateTime(2019, 1, 1),
                    PasswordHash = "ABCDFE",
                    PasswordSalt = "ABCFDD",
                    Username = "testuser1"
                },
                new KorisnickiNalog
                {
                    DateCreated = new DateTime(2019, 1, 1),
                    LastOnline = new DateTime(2019, 1, 1),
                    PasswordHash = "ABCDFE",
                    PasswordSalt = "ABCFDD",
                    Username = "testuser2"
                },
                new KorisnickiNalog
                {
                    DateCreated = new DateTime(2018, 1, 1),
                    LastOnline = new DateTime(2019, 1, 1),
                    PasswordHash = "ABCDFE",
                    PasswordSalt = "ABCFDD",
                    Username = "testuser3"
                },
                new KorisnickiNalog
                {
                    DateCreated = new DateTime(2018, 1, 1),
                    LastOnline = new DateTime(2019, 1, 1),
                    PasswordHash = "ABCDFE",
                    PasswordSalt = "ABCFDD",
                    Username = "testuser4"
                }
                );

            context.SaveChanges();
        }
    }
}