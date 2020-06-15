using HealthCare020.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Repository
{
    public class HealthCare020DbContext : DbContext
    {
        public HealthCare020DbContext(DbContextOptions<HealthCare020DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>()
                .HasOne(x => x.Drzava)
                .WithMany(x => x.Gradovi)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoleKorisnickiNalog>()
                .HasOne(x => x.KorisnickiNalog)
                .WithMany(x => x.RolesKorisnickiNalog)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ZahtevZaPregled>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.ZahteviZaPregled)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pregled>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.Pregledi)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Uputnica>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.Uputnice)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ZahtevZaPregled>()
                .HasOne(x => x.Doktor)
                .WithMany(x => x.ZahteviZaPregled)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pregled>()
                .HasOne(x => x.Doktor)
                .WithMany(x => x.Pregledi)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Uputnica>()
                .HasOne(x => x.UputioDoktor)
                .WithMany(x => x.UputniceUputio)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Uputnica>()
                .HasOne(x => x.UpucenKodDoktora)
                .WithMany(x => x.UputnicePrimio)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ZdravstvenaKnjizica>()
                .HasOne(x => x.LicniPodaci)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PacijentNaLecenju>()
                .HasOne(x => x.LicniPodaci)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<LicniPodaci> LicniPodaci { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalozi { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleKorisnickiNalog> RolesKorisnickiNalozi { get; set; }
        public DbSet<StacionarnoOdeljenje> StacionarnaOdeljenja { get; set; }
        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<MedicinskiTehnicar> MedicinskiTehnicari { get; set; }
        public DbSet<RadnikPrijem> RadniciPrijem { get; set; }
        public DbSet<NaucnaOblast> NaucneOblasti { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<ZdravstvenoStanje> ZdravstvenaStanja { get; set; }
        public DbSet<PacijentNaLecenju> PacijentiNaLecenju { get; set; }
        public DbSet<ZahtevZaPosetu> ZahteviZaPosetu { get; set; }
        public DbSet<ZahtevZaPregled> ZahteviZaPregled { get; set; }
        public DbSet<Uputnica> Uputnice { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }
        public DbSet<LekarskoUverenje> LekarskaUverenja { get; set; }
        public DbSet<ZdravstvenaKnjizica> ZdravstvenaKnjizica { get; set; }

    }
}