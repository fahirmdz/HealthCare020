﻿// <auto-generated />
using System;
using HealthCare020.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthCare020.Repository.Migrations
{
    [DbContext(typeof(HealthCare020DbContext))]
    [Migration("20200813125605_Added_VrijemePregledaUid")]
    partial class Added_VrijemePregledaUid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthCare020.Core.Entities.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NaucnaOblastId")
                        .HasColumnType("int");

                    b.Property<int>("RadnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NaucnaOblastId");

                    b.HasIndex("RadnikId");

                    b.ToTable("Doktori");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("PozivniBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastOnline")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockedOut")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockedOutUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalozi");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.LekarskoUverenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("OpisStanja")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("PregledId")
                        .HasColumnType("int");

                    b.Property<int>("ZdravstvenoStanjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PregledId");

                    b.HasIndex("ZdravstvenoStanjeId");

                    b.ToTable("LekarskaUverenja");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.LicniPodaci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("LicniPodaci");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.MedicinskiTehnicar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RadnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RadnikId");

                    b.ToTable("MedicinskiTehnicari");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.NaucnaOblast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("NaucneOblasti");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Pacijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<int>("ZdravstvenaKnjizicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("ZdravstvenaKnjizicaId");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.PacijentNaLecenju", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojSobe")
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<int>("StacionarnoOdeljenjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicniPodaciId");

                    b.HasIndex("StacionarnoOdeljenjeId");

                    b.ToTable("PacijentiNaLecenju");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPregleda")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOdradjen")
                        .HasColumnType("bit");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<long>("VrijemePregledaUid")
                        .HasColumnType("bigint");

                    b.Property<int>("ZahtevZaPregledId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("ZahtevZaPregledId");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Radnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<int>("StacionarnoOdeljenjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("LicniPodaciId");

                    b.HasIndex("StacionarnoOdeljenjeId");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.RadnikPrijem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RadnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RadnikId");

                    b.ToTable("RadniciPrijem");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.RoleKorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickiNalogId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesKorisnickiNalozi");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.StacionarnoOdeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("StacionarnaOdeljenja");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Uputnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<string>("Razlog")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpucenKodDoktoraId")
                        .HasColumnType("int");

                    b.Property<int>("UputioDoktorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId");

                    b.HasIndex("UpucenKodDoktoraId");

                    b.HasIndex("UputioDoktorId");

                    b.ToTable("Uputnice");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZahtevZaPosetu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojTelefonaPosetioca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumVremeKreiranja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsObradjen")
                        .HasColumnType("bit");

                    b.Property<int>("PacijentNaLecenjuId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ZakazanoDatumVreme")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PacijentNaLecenjuId");

                    b.ToTable("ZahteviZaPosetu");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZahtevZaPregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsObradjen")
                        .HasColumnType("bit");

                    b.Property<string>("Napomena")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<int?>("UputnicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("UputnicaId");

                    b.ToTable("ZahteviZaPregled");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZdravstvenaKnjizica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("LicniPodaciId");

                    b.ToTable("ZdravstvenaKnjizica");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZdravstvenoStanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("ZdravstvenaStanja");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Doktor", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.NaucnaOblast", "NaucnaOblast")
                        .WithMany()
                        .HasForeignKey("NaucnaOblastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Grad", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Drzava", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.LekarskoUverenje", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Doktor", null)
                        .WithMany("LekarskaUverenja")
                        .HasForeignKey("DoktorId");

                    b.HasOne("HealthCare020.Core.Entities.Pregled", "Pregled")
                        .WithMany()
                        .HasForeignKey("PregledId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.ZdravstvenoStanje", "ZdravstvenoStanje")
                        .WithMany()
                        .HasForeignKey("ZdravstvenoStanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.LicniPodaci", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.MedicinskiTehnicar", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Pacijent", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.ZdravstvenaKnjizica", "ZdravstvenaKnjizica")
                        .WithMany()
                        .HasForeignKey("ZdravstvenaKnjizicaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.PacijentNaLecenju", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.StacionarnoOdeljenje", "StacionarnoOdeljenje")
                        .WithMany()
                        .HasForeignKey("StacionarnoOdeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Pregled", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Doktor", "Doktor")
                        .WithMany("Pregledi")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Pacijent", "Pacijent")
                        .WithMany("Pregledi")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.ZahtevZaPregled", "ZahtevZaPregled")
                        .WithMany()
                        .HasForeignKey("ZahtevZaPregledId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Radnik", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.StacionarnoOdeljenje", "StacionarnoOdeljenje")
                        .WithMany()
                        .HasForeignKey("StacionarnoOdeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.RadnikPrijem", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.RoleKorisnickiNalog", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany("RolesKorisnickiNalog")
                        .HasForeignKey("KorisnickiNalogId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Uputnica", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Pacijent", "Pacijent")
                        .WithMany("Uputnice")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Doktor", "UpucenKodDoktora")
                        .WithMany("UputnicePrimio")
                        .HasForeignKey("UpucenKodDoktoraId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Doktor", "UputioDoktor")
                        .WithMany("UputniceUputio")
                        .HasForeignKey("UputioDoktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZahtevZaPosetu", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.PacijentNaLecenju", "PacijentNaLecenju")
                        .WithMany()
                        .HasForeignKey("PacijentNaLecenjuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZahtevZaPregled", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Doktor", "Doktor")
                        .WithMany("ZahteviZaPregled")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Pacijent", "Pacijent")
                        .WithMany("ZahteviZaPregled")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Uputnica", "Uputnica")
                        .WithMany()
                        .HasForeignKey("UputnicaId");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.ZdravstvenaKnjizica", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
