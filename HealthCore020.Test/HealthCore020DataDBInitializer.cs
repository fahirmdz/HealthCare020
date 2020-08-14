using HealthCare020.Core.Entities;
using HealthCare020.Repository;
using System;

namespace HealthCore020.Test
{
    public class HealthCore020DataDBInitializer
    {
        public static void Seed_ZdravstvenoStanje(HealthCare020DbContext context)
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

        public static void Seed_Drzave(HealthCare020DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Drzave.AddRange(
                new Drzava { Naziv = "TestNaziv1",PozivniBroj = "+123"},
                new Drzava { Naziv = "TestNaziv2",PozivniBroj = "+124" },
                new Drzava { Naziv = "TestNaziv3",PozivniBroj = "+125" },
                new Drzava { Naziv = "TestNaziv4",PozivniBroj = "+126" },
                new Drzava { Naziv = "TestNaziv5",PozivniBroj = "+127" },
                new Drzava { Naziv = "TestNaziv6",PozivniBroj = "+128" }
            );

            context.SaveChanges();
        }


        public static void Seed_Korisnik(HealthCare020DbContext context)
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