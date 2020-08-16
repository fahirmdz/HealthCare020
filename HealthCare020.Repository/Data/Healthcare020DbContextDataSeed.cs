using System;
using System.Collections.Generic;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Security;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Repository
{
    public partial class HealthCare020DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
               var drzave = new List<Drzava>
            {
                new Drzava {Id = 1, Naziv = "Bosna i Hercegovina", PozivniBroj = "387"},
                new Drzava {Id = 2, Naziv = "Srbija", PozivniBroj = "381"},
                new Drzava {Id = 3, Naziv = "Crna Gora", PozivniBroj = "382"}
            };

            modelBuilder.Entity<Drzava>().HasData(drzave);
            var gradovi = new List<Grad>
            {
                new Grad {Id = 1, DrzavaId = 1, Naziv = "Sarajevo"},
                new Grad {Id = 2, DrzavaId = 1, Naziv = "Mostar"},
                new Grad {Id = 3, DrzavaId = 1, Naziv = "Zenica"},
                new Grad {Id = 4, DrzavaId = 1, Naziv = "Visoko"},
                new Grad {Id = 5, DrzavaId = 1, Naziv = "Goražde"},
                new Grad {Id = 6, DrzavaId = 2, Naziv = "Novi Pazar"},
                new Grad {Id = 7, DrzavaId = 2, Naziv = "Beograd"},
                new Grad {Id = 8, DrzavaId = 2, Naziv = "Novi Sad"},
                new Grad {Id = 9, DrzavaId = 2, Naziv = "Subotica"},
                new Grad {Id = 10, DrzavaId = 2, Naziv = "Kraljevo"},
                new Grad {Id = 11, DrzavaId = 3, Naziv = "Podgorica"},
                new Grad {Id = 12, DrzavaId = 3, Naziv = "Budva"},
                new Grad {Id = 13, DrzavaId = 3, Naziv = "Tivat"}
            };
            modelBuilder.Entity<Grad>().HasData(gradovi);

            var zdravstvenaStanja = new List<ZdravstvenoStanje>
            {
                new ZdravstvenoStanje{Id=1, Opis = "Odlično"},
                new ZdravstvenoStanje{Id=2, Opis = "Dobro"},
                new ZdravstvenoStanje{Id=3, Opis = "Pod kontrolom"},
                new ZdravstvenoStanje{Id=4, Opis = "Otežano"},
                new ZdravstvenoStanje{Id=5, Opis = "Loše"}
            };
            modelBuilder.Entity<ZdravstvenoStanje>().HasData(zdravstvenaStanja);

            var roles = new List<Role>
            {
                new Role{Id=1, Naziv = "Administrator"},
                new Role{Id=2, Naziv = "Doktor"},
                new Role{Id=3, Naziv = "MedicinckiTehnicar"},
                new Role{Id=4, Naziv = "RadnikPrijem"},
                new Role{Id=5, Naziv = "Pacijent"}
            };
            modelBuilder.Entity<Role>().HasData(roles);

            var stacionarnaOdeljenja = new List<StacionarnoOdeljenje>
            {
                new StacionarnoOdeljenje{Id=1, Naziv = "Hiruško"},
                new StacionarnoOdeljenje{Id=2, Naziv = "Plućno"},
                new StacionarnoOdeljenje{Id=3, Naziv = "Ortopedijsko"},
                new StacionarnoOdeljenje{Id=4, Naziv = "Koronarno"}
            };
            modelBuilder.Entity<StacionarnoOdeljenje>().HasData(stacionarnaOdeljenja);

            var naucneOblasti = new List<NaucnaOblast>
            {
                new NaucnaOblast {Id = 1, Naziv = "Hirurgija"},
                new NaucnaOblast {Id = 2, Naziv = "Endokrinologija"},
                new NaucnaOblast {Id = 3, Naziv = "Neurohirurgija"},
                new NaucnaOblast {Id = 4, Naziv = "Reumatologija"},
                new NaucnaOblast {Id = 5, Naziv = "Kardiologija"},
                new NaucnaOblast {Id = 6, Naziv = "Fizijatrija"},
            };
            modelBuilder.Entity<NaucnaOblast>().HasData(naucneOblasti);

            var securityService = new SecurityService();
            var salts = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                salts.Add(securityService.GenerateSalt());
            }

            var korisnickiNalozi = new List<KorisnickiNalog>
            {
                new KorisnickiNalog
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    FaceId = null,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[0],"testtest"),
                    PasswordSalt = salts[0],
                    Username="admin"
                },
                new KorisnickiNalog
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[1],"testtest"),
                    PasswordSalt = salts[1],
                    Username="doktor"
                },
                new KorisnickiNalog
                {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[2],"testtest"),
                    PasswordSalt = salts[2],
                    Username="radnikprijem"
                },
                new KorisnickiNalog
                {
                    Id = 4,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[3],"testtest"),
                    PasswordSalt = salts[3],
                    Username="pacijent"
                },
                new KorisnickiNalog
                {
                    Id = 5,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[4],"testtest"),
                    PasswordSalt = salts[4],
                    Username="medicinskitehnicar"
                },
                new KorisnickiNalog
                {
                    Id = 6,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[5],"testtest"),
                    PasswordSalt = salts[5],
                    Username="doktor2"
                },
                new KorisnickiNalog
                {
                    Id = 7,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[6],"testtest"),
                    PasswordSalt = salts[6],
                    Username="pacijent2"
                },
                new KorisnickiNalog
                {
                    Id = 8,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[7],"testtest"),
                    PasswordSalt = salts[7],
                    Username="pacijent3"
                },
                new KorisnickiNalog
                {
                    Id = 9,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[8],"testtest"),
                    PasswordSalt = salts[8],
                    Username="pacijent4"
                },
                new KorisnickiNalog
                {
                    Id = 10,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[9],"testtest"),
                    PasswordSalt = salts[9],
                    Username="pacijent5"
                },
                new KorisnickiNalog
                {
                    Id = 11,
                    DateCreated = DateTime.Now,
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[10],"testtest"),
                    PasswordSalt = salts[10],
                    Username="pacijent6"
                },
                new KorisnickiNalog
                {
                    Id = 12,
                    DateCreated = DateTime.Now.AddMonths(-1),
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[11],"testtest"),
                    PasswordSalt = salts[11],
                    Username="pacijent7"
                },
                new KorisnickiNalog
                {
                    Id = 13,
                    DateCreated = DateTime.Now.AddMonths(-2),
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[12],"testtest"),
                    PasswordSalt = salts[12],
                    Username="pacijent8"
                },
                new KorisnickiNalog
                {
                    Id = 14,
                    DateCreated = DateTime.Now.AddMonths(-2),
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[13],"testtest"),
                    PasswordSalt = salts[13],
                    Username="pacijent9"
                },
                new KorisnickiNalog
                {
                    Id = 15,
                    DateCreated = DateTime.Now.AddMonths(-4),
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[14],"testtest"),
                    PasswordSalt = salts[14],
                    Username="pacijent10"
                },
                new KorisnickiNalog
                {
                    Id = 16,
                    DateCreated = DateTime.Now.AddMonths(-4),
                    LastOnline = DateTime.Now,
                    LockedOut = false,
                    PasswordHash =securityService.GenerateHash(salts[15],"testtest"),
                    PasswordSalt = salts[15],
                    Username="pacijent11"
                },

            };
            modelBuilder.Entity<KorisnickiNalog>().HasData(korisnickiNalozi);


            var rolesKorisnickiNalog = new List<RoleKorisnickiNalog>
            {
                new RoleKorisnickiNalog{Id=1,KorisnickiNalogId = 1,RoleId = 1},
                new RoleKorisnickiNalog{Id=2,KorisnickiNalogId = 1,RoleId = 2},
                new RoleKorisnickiNalog{Id=3,KorisnickiNalogId = 1,RoleId = 3},
                new RoleKorisnickiNalog{Id=4,KorisnickiNalogId = 1,RoleId = 4},
                new RoleKorisnickiNalog{Id=5,KorisnickiNalogId = 1,RoleId = 5},
                new RoleKorisnickiNalog{Id=6,KorisnickiNalogId = 2,RoleId = 2},
                new RoleKorisnickiNalog{Id=7,KorisnickiNalogId = 2,RoleId = 3},
                new RoleKorisnickiNalog{Id=8,KorisnickiNalogId = 2,RoleId = 4},
                new RoleKorisnickiNalog{Id=9,KorisnickiNalogId = 2,RoleId = 5},
                new RoleKorisnickiNalog{Id=10,KorisnickiNalogId = 5,RoleId = 3},
                new RoleKorisnickiNalog{Id=11,KorisnickiNalogId = 5,RoleId = 4},
                new RoleKorisnickiNalog{Id=12,KorisnickiNalogId = 5,RoleId = 5},
                new RoleKorisnickiNalog{Id=14,KorisnickiNalogId = 3,RoleId = 4},
                new RoleKorisnickiNalog{Id=15,KorisnickiNalogId = 4,RoleId = 5},
                new RoleKorisnickiNalog{Id=16,KorisnickiNalogId = 6,RoleId = 2},
                new RoleKorisnickiNalog{Id=17,KorisnickiNalogId = 6,RoleId = 3},
                new RoleKorisnickiNalog{Id=18,KorisnickiNalogId = 6,RoleId = 4},
                new RoleKorisnickiNalog{Id=19,KorisnickiNalogId = 6,RoleId = 5},
                new RoleKorisnickiNalog{Id=20,KorisnickiNalogId = 7,RoleId = 5},
                new RoleKorisnickiNalog{Id=21,KorisnickiNalogId = 8,RoleId = 5},
                new RoleKorisnickiNalog{Id=22,KorisnickiNalogId = 9,RoleId = 5},
                new RoleKorisnickiNalog{Id=23,KorisnickiNalogId = 10,RoleId = 5},
                new RoleKorisnickiNalog{Id=24,KorisnickiNalogId = 11,RoleId = 5},
                new RoleKorisnickiNalog{Id=25,KorisnickiNalogId = 12,RoleId = 5},
                new RoleKorisnickiNalog{Id=26,KorisnickiNalogId = 13,RoleId = 5},
                new RoleKorisnickiNalog{Id=27,KorisnickiNalogId = 14,RoleId = 5},
                new RoleKorisnickiNalog{Id=28,KorisnickiNalogId = 15,RoleId = 5},
                new RoleKorisnickiNalog{Id=29,KorisnickiNalogId = 16,RoleId = 5},

            };

            modelBuilder.Entity<RoleKorisnickiNalog>().HasData(rolesKorisnickiNalog);

            var licniPodaci = new List<LicniPodaci>
            {
                new LicniPodaci
                {
                    Id=1,
                    Adresa = "Gradacacka 10",
                    BrojTelefona = "0624322123",
                    JMBG="010202001",
                    DatumRodjenja = DateTime.Now.AddYears(-40),
                    EmailAddress = "doktor1@live.com",
                    GradId = 1,
                    Ime = "Fahir",
                    Prezime = "Dokt",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=2,
                    Adresa = "Envera Seh 10",
                    JMBG="013412333",
                    BrojTelefona = "062414322",
                    DatumRodjenja = DateTime.Now.AddYears(-32),
                    EmailAddress = "prijem1@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Prijem",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=3,
                    Adresa = "Alojza Benca 10",
                    JMBG="013475855",
                    BrojTelefona = "067231222",
                    DatumRodjenja = DateTime.Now.AddYears(-47),
                    EmailAddress = "pacijent1@live.com",
                    GradId = 4,
                    Ime = "Fahir",
                    Prezime = "Pacijent",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=4,
                    Adresa = "Seiz 10",
                    JMBG="1475856888",
                    BrojTelefona = "064322233",
                    DatumRodjenja = DateTime.Now.AddYears(-50),
                    EmailAddress = "medtehnicar1@live.com",
                    GradId = 5,
                    Ime = "Fahir",
                    Prezime = "Tehnicar",
                    Pol = 'M',
                }
                ,
                new LicniPodaci
                {
                    Id=5,
                    Adresa = "Helst 12",
                    JMBG="1154651655",
                    BrojTelefona = "06123233",
                    DatumRodjenja = DateTime.Now.AddYears(-29),
                    EmailAddress = "doktor2@live.com",
                    GradId = 3,
                    Ime = "Fahir",
                    Prezime = "Doktdva",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=6,
                    Adresa = "Neumsd 12",
                    JMBG="7584247777",
                    BrojTelefona = "066585255",
                    DatumRodjenja = DateTime.Now.AddYears(-24),
                    EmailAddress = "pacijentlecenje1@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Lecenje",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=7,
                    Adresa = "Reu 12",
                    JMBG="2557766355",
                    BrojTelefona = "06585524",
                    DatumRodjenja = DateTime.Now.AddYears(-54),
                    EmailAddress = "pacijentlecenje2@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Lecenjedva",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=8,
                    Adresa = "Golubacka 12",
                    JMBG="2534123332",
                    BrojTelefona = "063412333",
                    DatumRodjenja = DateTime.Now.AddYears(-27),
                    EmailAddress = "pacijent3@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacdva",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=9,
                    Adresa = "Reu 17",
                    JMBG="25111020201",
                    BrojTelefona = "0612323333",
                    DatumRodjenja = DateTime.Now.AddYears(-27),
                    EmailAddress = "pacijent4@live.com",
                    GradId = 5,
                    Ime = "Fahir",
                    Prezime = "Pactri",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=10,
                    Adresa = "Leur 91",
                    JMBG="2557766355",
                    BrojTelefona = "06585524",
                    DatumRodjenja = DateTime.Now.AddYears(-27).AddDays(15),
                    EmailAddress = "pacijent5@live.com",
                    GradId = 3,
                    Ime = "Fahir",
                    Prezime = "Paccetiri",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=11,
                    Adresa = "Reu 12",
                    JMBG="2574214855",
                    BrojTelefona = "060365955",
                    DatumRodjenja = DateTime.Now.AddYears(-41),
                    EmailAddress = "pacijent6@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacpet",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=12,
                    Adresa = "Topolska 18",
                    JMBG="84575856999",
                    BrojTelefona = "06585524",
                    DatumRodjenja = DateTime.Now.AddYears(-41).AddMonths(1),
                    EmailAddress = "pacijent7@live.com",
                    GradId = 3,
                    Ime = "Fahir",
                    Prezime = "Pacsest",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=13,
                    Adresa = "Envera Sehovica 19",
                    JMBG="85442222222",
                    BrojTelefona = "0675845555",
                    DatumRodjenja = DateTime.Now.AddYears(-41).AddMonths(-3),
                    EmailAddress = "pacijent8@live.com",
                    GradId = 5,
                    Ime = "Fahir",
                    Prezime = "Pacsedam",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=14,
                    Adresa = "Reu 12",
                    JMBG="2551876355",
                    BrojTelefona = "06585524",
                    DatumRodjenja = DateTime.Now.AddYears(-64),
                    EmailAddress = "pacijent9@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacosam",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=15,
                    Adresa = "Bosanskih gazija 9",
                    JMBG="2557766355",
                    BrojTelefona = "065234121",
                    DatumRodjenja = DateTime.Now.AddYears(-64).AddMonths(-1),
                    EmailAddress = "pacijent10@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacdevet",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=16,
                    Adresa = "Frau Hermanova 2",
                    JMBG="8422222211",
                    BrojTelefona = "0625485477",
                    DatumRodjenja = DateTime.Now.AddYears(-64).AddMonths(-3),
                    EmailAddress = "pacijent11@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacdeset",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=17,
                    Adresa = "Sarajevska 25",
                    JMBG="8352121332",
                    BrojTelefona = "068575853",
                    DatumRodjenja = DateTime.Now.AddYears(-35),
                    EmailAddress = "pacijent12@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacjedanaest",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=18,
                    Adresa = "Sarajevska 100",
                    JMBG="1234567891",
                    BrojTelefona = "0624745855",
                    DatumRodjenja = DateTime.Now.AddYears(-24),
                    EmailAddress = "pacijent20@live.com",
                    GradId = 2,
                    Ime = "Fahir",
                    Prezime = "Pacdvadeset",
                    Pol = 'M',
                },
                new LicniPodaci
                {
                    Id=19,
                    Adresa = "Lumbago 100",
                    JMBG="9874563211",
                    BrojTelefona = "0624234123",
                    DatumRodjenja = DateTime.Now.AddYears(-54),
                    EmailAddress = "pacijent21@live.com",
                    GradId = 4,
                    Ime = "Fahir",
                    Prezime = "Pacdvajedan",
                    Pol = 'M',
                }
            };

            modelBuilder.Entity<LicniPodaci>().HasData(licniPodaci);

            var radnici = new List<Radnik>
            {
                new Radnik
                {
                    Id = 1,
                    KorisnickiNalogId = 2,
                    LicniPodaciId = 1,
                    StacionarnoOdeljenjeId=1
                },
                new Radnik
                {
                    Id = 2,
                    KorisnickiNalogId = 3,
                    LicniPodaciId = 2,
                    StacionarnoOdeljenjeId=1,
                },
                new Radnik
                {
                    Id = 3,
                    KorisnickiNalogId = 5,
                    LicniPodaciId = 4,
                    StacionarnoOdeljenjeId=1,
                },
                new Radnik
                {
                    Id = 4,
                    KorisnickiNalogId = 6,
                    LicniPodaciId = 5,
                    StacionarnoOdeljenjeId=2,
                }
            };
            modelBuilder.Entity<Radnik>().HasData(radnici);

            var doktori = new List<Doktor>
            {
                new Doktor
                {
                    Id = 1,
                    NaucnaOblastId = 1,
                    RadnikId = 1
                },
                new Doktor
                {
                    Id=2,
                    NaucnaOblastId = 2,
                    RadnikId=4
                }
            };
            modelBuilder.Entity<Doktor>().HasData(doktori);

            var medicinskiTehnicari = new List<MedicinskiTehnicar>
            {
                new MedicinskiTehnicar
                {
                    Id=1,
                    RadnikId = 3
                }
            };
            modelBuilder.Entity<MedicinskiTehnicar>().HasData(medicinskiTehnicari);

            var radniciPrijem = new List<RadnikPrijem>
            {
                new RadnikPrijem
                {
                    Id=1,
                    RadnikId = 2
                }
            };
            modelBuilder.Entity<RadnikPrijem>().HasData(radniciPrijem);


            var zdravstveneKnjizice = new List<ZdravstvenaKnjizica>
            {
                new ZdravstvenaKnjizica
                {
                    Id=1,
                    DoktorId = 1,
                    LicniPodaciId = 3
                },
                new ZdravstvenaKnjizica
                {
                    Id=2,
                    DoktorId = 1,
                    LicniPodaciId = 8
                },
                new ZdravstvenaKnjizica
                {
                    Id=3,
                    DoktorId = 1,
                    LicniPodaciId = 9
                },
                new ZdravstvenaKnjizica
                {
                    Id=4,
                    DoktorId = 1,
                    LicniPodaciId = 10
                },
                new ZdravstvenaKnjizica
                {
                    Id=5,
                    DoktorId = 1,
                    LicniPodaciId = 11
                },
                new ZdravstvenaKnjizica
                {
                    Id=6,
                    DoktorId = 1,
                    LicniPodaciId = 12
                },
                new ZdravstvenaKnjizica
                {
                    Id=7,
                    DoktorId = 1,
                    LicniPodaciId = 13
                },
                new ZdravstvenaKnjizica
                {
                    Id=8,
                    DoktorId = 1,
                    LicniPodaciId = 14
                },
                new ZdravstvenaKnjizica
                {
                    Id=9,
                    DoktorId = 1,
                    LicniPodaciId = 15
                },
                new ZdravstvenaKnjizica
                {
                    Id=10,
                    DoktorId = 1,
                    LicniPodaciId = 16
                },
                new ZdravstvenaKnjizica
                {
                    Id=11,
                    DoktorId = 1,
                    LicniPodaciId = 17
                },
                new ZdravstvenaKnjizica
                {
                    Id=12,
                    DoktorId = 1,
                    LicniPodaciId = 18
                },
                new ZdravstvenaKnjizica
                {
                    Id=13,
                    DoktorId = 1,
                    LicniPodaciId = 19
                }
            };
            modelBuilder.Entity<ZdravstvenaKnjizica>().HasData(zdravstveneKnjizice);

            foreach(var zk in zdravstveneKnjizice){}

            var pacijenti = new List<Pacijent>
            {
                new Pacijent
                {
                    Id = 1,
                    KorisnickiNalogId = 4,
                    ZdravstvenaKnjizicaId = 1
                },
                new Pacijent
                {
                    Id = 2,
                    KorisnickiNalogId = 7,
                    ZdravstvenaKnjizicaId = 2
                },
                new Pacijent
                {
                    Id = 3,
                    KorisnickiNalogId = 8,
                    ZdravstvenaKnjizicaId = 3
                },
                new Pacijent
                {
                    Id = 4,
                    KorisnickiNalogId = 9,
                    ZdravstvenaKnjizicaId = 4
                },
                new Pacijent
                {
                    Id = 5,
                    KorisnickiNalogId = 10,
                    ZdravstvenaKnjizicaId = 5
                },
                new Pacijent
                {
                    Id = 6,
                    KorisnickiNalogId = 11,
                    ZdravstvenaKnjizicaId = 6
                },
                new Pacijent
                {
                    Id = 7,
                    KorisnickiNalogId = 12,
                    ZdravstvenaKnjizicaId = 7
                },
                new Pacijent
                {
                    Id = 8,
                    KorisnickiNalogId = 13,
                    ZdravstvenaKnjizicaId = 8
                },
                new Pacijent
                {
                    Id = 9,
                    KorisnickiNalogId = 14,
                    ZdravstvenaKnjizicaId = 9
                },
                new Pacijent
                {
                    Id = 10,
                    KorisnickiNalogId = 15,
                    ZdravstvenaKnjizicaId = 10
                },
                new Pacijent
                {
                    Id = 11,
                    KorisnickiNalogId = 16,
                    ZdravstvenaKnjizicaId = 11
                }
            };
            modelBuilder.Entity<Pacijent>().HasData(pacijenti);


            var zahteviZaPregled = new List<ZahtevZaPregled>
            {
                new ZahtevZaPregled
                {
                    Id=1,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddDays(-2),
                    IsObradjen = true,
                    Napomena = "Otežano disanje",
                    PacijentId = 1
                },
                new ZahtevZaPregled
                {
                    Id=2,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddDays(-3),
                    IsObradjen = false,
                    Napomena = "Problemi sa mokraćnim kanalima",
                    PacijentId = 1
                }
                ,
                new ZahtevZaPregled
                {
                    Id=3,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-1),
                    IsObradjen = true,
                    Napomena = "Problemi sa disanjem",
                    PacijentId = 1
                },
                new ZahtevZaPregled
                {
                    Id=4,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Problemi sa radom srca",
                    PacijentId = 1
                },
                new ZahtevZaPregled
                {
                    Id=5,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-4),
                    IsObradjen = true,
                    Napomena = "Razredjena krv",
                    PacijentId = 1
                },
                new ZahtevZaPregled
                {
                    Id=6,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-8),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u grudima",
                    PacijentId = 1
                },
                new ZahtevZaPregled
                {
                    Id=7,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-4),
                    IsObradjen = true,
                    Napomena = "Bolovi u glavi",
                    PacijentId = 2
                },
                new ZahtevZaPregled
                {
                    Id=8,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u vratu",
                    PacijentId = 2
                },
                new ZahtevZaPregled
                {
                    Id=9,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u slepoocnici",
                    PacijentId = 3
                },
                new ZahtevZaPregled
                {
                    Id=10,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-1),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u grudima",
                    PacijentId = 4
                },
                new ZahtevZaPregled
                {
                    Id=11,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-3),
                    IsObradjen = true,
                    Napomena = "Peckanje u ocima",
                    PacijentId = 5
                },
                new ZahtevZaPregled
                {
                    Id=12,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Bolovi u stomaku",
                    PacijentId = 6
                },
                new ZahtevZaPregled
                {
                    Id=13,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u zeludcu",
                    PacijentId = 7
                },
                new ZahtevZaPregled
                {
                    Id=14,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-1).AddDays(3),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u ramenu",
                    PacijentId = 8
                },
                new ZahtevZaPregled
                {
                    Id=15,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-2).AddDays(9),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u ocima",
                    PacijentId = 9
                },
                new ZahtevZaPregled
                {
                    Id=16,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddMonths(-2),
                    IsObradjen = true,
                    Napomena = "Blagi bolovi u ceonom dijelu",
                    PacijentId = 10
                },
                new ZahtevZaPregled
                {
                    Id=17,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddDays(-2),
                    IsObradjen = false,
                    Napomena = "Blagi bolovi u stomaku",
                    PacijentId = 2
                },
                new ZahtevZaPregled
                {
                    Id=18,
                    DoktorId = 2,
                    DatumVreme = DateTime.Now.AddDays(-2),
                    IsObradjen = false,
                    Napomena = "Blagi bolovi u zeludcu",
                    PacijentId = 8
                },
                new ZahtevZaPregled
                {
                    Id=19,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddDays(-2),
                    IsObradjen = false,
                    Napomena = "Blagi bolovi u stomaku",
                    PacijentId = 2
                },
                new ZahtevZaPregled
                {
                    Id=20,
                    DoktorId = 1,
                    DatumVreme = DateTime.Now.AddDays(-2),
                    IsObradjen = false,
                    Napomena = "Blagi bolovi u zeludcu",
                    PacijentId = 8
                },
            };
            modelBuilder.Entity<ZahtevZaPregled>().HasData(zahteviZaPregled);

            var pregledi = new List<Pregled>
            {
                new Pregled
                {
                    Id=1,
                    ZahtevZaPregledId = 1,
                    DatumPregleda = DateTime.Today.AddMonths(-2).AddDays(-4).AddHours(10),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=1,
                    VrijemePregledaUid = 2
                },
                new Pregled
                {
                    Id=2,
                    ZahtevZaPregledId = 3,
                    DatumPregleda = DateTime.Today.AddMonths(-2).AddDays(-3).AddHours(10),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=1,
                    VrijemePregledaUid = 2
                },
                new Pregled
                {
                    Id=3,
                    ZahtevZaPregledId = 4,
                    DatumPregleda = DateTime.Today.AddMonths(-2).AddDays(-2).AddHours(10),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=1,
                    VrijemePregledaUid = 2
                },
                new Pregled
                {
                    Id=4,
                    ZahtevZaPregledId = 5,
                    DatumPregleda = DateTime.Today.AddMonths(-2).AddDays(-1).AddHours(10),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=1,
                    VrijemePregledaUid = 2
                },
                new Pregled
                {
                    Id=5,
                    ZahtevZaPregledId = 6,
                    DatumPregleda = DateTime.Today.AddMonths(-2).AddHours(10),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=1,
                    VrijemePregledaUid = 2
                },
                new Pregled
                {
                    Id=6,
                    ZahtevZaPregledId = 7,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(12),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=2,
                    VrijemePregledaUid = 6
                },
                new Pregled
                {
                    Id=7,
                    ZahtevZaPregledId = 8,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(12),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=2,
                    VrijemePregledaUid = 6
                },
                new Pregled
                {
                    Id=8,
                    ZahtevZaPregledId = 9,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(12),
                    DoktorId = 1,
                    IsOdradjen = true,
                    PacijentId=3,
                    VrijemePregledaUid = 6
                },
                new Pregled
                {
                    Id=9,
                    ZahtevZaPregledId = 10,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(12),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=4,
                    VrijemePregledaUid = 6
                },
                new Pregled
                {
                    Id=10,
                    ZahtevZaPregledId = 11,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(14),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=5,
                    VrijemePregledaUid = 10
                },
                new Pregled
                {
                    Id=11,
                    ZahtevZaPregledId = 12,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(14),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=6,
                    VrijemePregledaUid = 10
                },
                new Pregled
                {
                    Id=12,
                    ZahtevZaPregledId = 13,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(14),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=7,
                    VrijemePregledaUid = 10
                },
                new Pregled
                {
                    Id=13,
                    ZahtevZaPregledId = 14,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(15),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=8,
                    VrijemePregledaUid = 12
                },
                new Pregled
                {
                    Id=14,
                    ZahtevZaPregledId = 15,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(15),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=9,
                    VrijemePregledaUid = 12
                },
                new Pregled
                {
                    Id=15,
                    ZahtevZaPregledId = 16,
                    DatumPregleda = DateTime.Today.AddMonths(-1).AddDays(2).AddHours(15),
                    DoktorId = 2,
                    IsOdradjen = true,
                    PacijentId=10,
                    VrijemePregledaUid = 12
                },
            };


            modelBuilder.Entity<Pregled>().HasData(pregledi);

            var lekarskaUverenja = new List<LekarskoUverenje>
            {
                new LekarskoUverenje
                {
                    Id=1,
                    PregledId = 1,
                    ZdravstvenoStanjeId = 3,
                    OpisStanja = "Stanje je za sada pod kontrolom"
                },
                new LekarskoUverenje
                {
                    Id=2,
                    PregledId = 2,
                    ZdravstvenoStanjeId = 2,
                    OpisStanja = "Test opis"
                },
                new LekarskoUverenje
                {
                    Id=3,
                    PregledId = 3,
                    ZdravstvenoStanjeId = 3,
                    OpisStanja = "Stanje je za sada pod kontrolom"
                },
                new LekarskoUverenje
                {
                    Id=4,
                    PregledId = 4,
                    ZdravstvenoStanjeId = 3,
                    OpisStanja = "Stanje je za sada pod kontrolom"
                },
                new LekarskoUverenje
                {
                    Id=5,
                    PregledId = 5,
                    ZdravstvenoStanjeId = 3,
                    OpisStanja = "Stanje je za sada pod kontrolom"
                }
            };
            modelBuilder.Entity<LekarskoUverenje>().HasData(lekarskaUverenja);

            var uputnice = new List<Uputnica>
            {
                new Uputnica
                {
                    Id = 1,
                    UputioDoktorId = 1,
                    UpucenKodDoktoraId = 2,
                    PacijentId = 1,
                    DatumVreme = DateTime.Now.AddDays(-1),
                    Napomena = "Pregledati urnarni trakt",
                    Razlog = "Mucnina u stomaku"
                },
                new Uputnica
                {
                    Id = 2,
                    UputioDoktorId = 2,
                    UpucenKodDoktoraId = 1,
                    PacijentId = 1,
                    DatumVreme = DateTime.Now.AddDays(-1),
                    Napomena = "Pregledati glavu",
                    Razlog = "Bol u slepoocnici"
                },
                new Uputnica
                {
                    Id = 3,
                    UputioDoktorId = 1,
                    UpucenKodDoktoraId = 2,
                    PacijentId = 2,
                    DatumVreme = DateTime.Now.AddDays(-1),
                    Napomena = "Pregledati urnarni trakt",
                    Razlog = "Mucnina u stomaku"
                },
                new Uputnica
                {
                    Id = 4,
                    UputioDoktorId = 2,
                    UpucenKodDoktoraId = 1,
                    PacijentId = 2,
                    DatumVreme = DateTime.Now.AddDays(-1),
                    Napomena = "Pregledati urnarni trakt",
                    Razlog = "Mucnina u stomaku"
                }
            };
            modelBuilder.Entity<Uputnica>().HasData(uputnice);


            var pacijentiLecenje = new List<PacijentNaLecenju>
            {
                new PacijentNaLecenju
                {
                    Id=1,
                    LicniPodaciId = 6,
                    StacionarnoOdeljenjeId=1,
                    BrojSobe = 16
                },
                new PacijentNaLecenju
                {
                    Id=2,
                    LicniPodaciId = 7,
                    StacionarnoOdeljenjeId=1,
                    BrojSobe = 16
                }
            };
            modelBuilder.Entity<PacijentNaLecenju>().HasData(pacijentiLecenje);

            var zahteviZaPosetu = new List<ZahtevZaPosetu>
            {
                new ZahtevZaPosetu
                {
                    Id = 1,
                    BrojTelefonaPosetioca = "066985295",
                    DatumVremeKreiranja = DateTime.Today.AddDays(-4),
                    ZakazanoDatumVreme = DateTime.Today.AddDays(-5).AddHours(14.5),
                    IsObradjen = true,
                    PacijentNaLecenjuId = 1,
                },
                new ZahtevZaPosetu
                {
                    Id = 2,
                    BrojTelefonaPosetioca = "066585777",
                    DatumVremeKreiranja = DateTime.Now.AddDays(-4),
                    IsObradjen = false,
                    PacijentNaLecenjuId = 2,
                }
            };
            modelBuilder.Entity<ZahtevZaPosetu>().HasData(zahteviZaPosetu);

        }
    }
}