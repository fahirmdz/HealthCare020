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
    [Migration("20200428200510_Removed_ImePrezimePosetioca_From_Poseta")]
    partial class Removed_ImePrezimePosetioca_From_Poseta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthCare020.Core.Entities.CustomIzvestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<double>("GlukozaUKrvi")
                        .HasColumnType("float");

                    b.Property<int>("KrvniPritisakDonji")
                        .HasColumnType("int");

                    b.Property<int>("KrvniPritisakGornji")
                        .HasColumnType("int");

                    b.Property<int>("MedicinskiTehnicarId")
                        .HasColumnType("int");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<double>("TelesnaTemperatura")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MedicinskiTehnicarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("CustomIzvestaji");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.DnevniIzvestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicinskiTehnicarId")
                        .HasColumnType("int");

                    b.Property<string>("OpisStanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<int>("ZdravstvenoStanjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicinskiTehnicarId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("ZdravstvenoStanjeId");

                    b.ToTable("DnevniIzvestaji");
                });

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

                    b.Property<DateTime>("LastOnline")
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
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

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

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<int>("TokenPosetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LicniPodaciId");

                    b.HasIndex("TokenPosetaId");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Poseta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PacijentId")
                        .HasColumnType("int");

                    b.Property<int>("TokenPosetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId");

                    b.HasIndex("TokenPosetaId");

                    b.ToTable("Posete");
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

            modelBuilder.Entity("HealthCare020.Core.Entities.TokenPoseta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPreostalihPoseta")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("TokeniPoseta");
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.UputZaLecenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVreme")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("LicniPodaciId")
                        .HasColumnType("int");

                    b.Property<string>("OpisStanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("LicniPodaciId");

                    b.ToTable("UputiZaLecenje");
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

            modelBuilder.Entity("HealthCare020.Core.Entities.CustomIzvestaj", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.MedicinskiTehnicar", "MedicinskiTehnicar")
                        .WithMany("CustomIzvestaji")
                        .HasForeignKey("MedicinskiTehnicarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Pacijent", "Pacijent")
                        .WithMany("CustomIzvestaji")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.DnevniIzvestaj", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.MedicinskiTehnicar", "MedicinskiTehnicar")
                        .WithMany("DnevniIzvestaji")
                        .HasForeignKey("MedicinskiTehnicarId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.Pacijent", "Pacijent")
                        .WithMany("DnevniIzvestaji")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.ZdravstvenoStanje", "ZdravstvenoStanje")
                        .WithMany()
                        .HasForeignKey("ZdravstvenoStanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("HealthCare020.Core.Entities.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.TokenPoseta", "TokenPoseta")
                        .WithMany()
                        .HasForeignKey("TokenPosetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthCare020.Core.Entities.Poseta", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Pacijent", null)
                        .WithMany("Posete")
                        .HasForeignKey("PacijentId");

                    b.HasOne("HealthCare020.Core.Entities.TokenPoseta", "TokenPoseta")
                        .WithMany("Posete")
                        .HasForeignKey("TokenPosetaId")
                        .OnDelete(DeleteBehavior.Restrict)
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

            modelBuilder.Entity("HealthCare020.Core.Entities.UputZaLecenje", b =>
                {
                    b.HasOne("HealthCare020.Core.Entities.Doktor", "Doktor")
                        .WithMany("UputiZaLecenje")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCare020.Core.Entities.LicniPodaci", "LicniPodaci")
                        .WithMany()
                        .HasForeignKey("LicniPodaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
