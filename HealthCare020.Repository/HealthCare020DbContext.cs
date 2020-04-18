using HealthCare020.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthCare020.Repository
{
    public class HealthCare020DbContext : DbContext
    {
        public HealthCare020DbContext(DbContextOptions<HealthCare020DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UputZaLecenje>()
                .HasOne(x => x.Doktor)
                .WithMany(x => x.UputiZaLecenje)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grad>()
                .HasOne(x => x.Drzava)
                .WithMany(x => x.Gradovi)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DnevniIzvestaj>()
                .HasOne(x => x.MedicinskiTehnicar)
                .WithMany(x => x.DnevniIzvestaji)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomIzvestaj>()
                .HasOne(x => x.MedicinskiTehnicar)
                .WithMany(x => x.CustomIzvestaji)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomIzvestaj>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.CustomIzvestaji)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DnevniIzvestaj>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.DnevniIzvestaji)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Poseta>()
                .HasOne(x => x.Pacijent)
                .WithMany(x => x.Posete)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RoleKorisnickiNalog>()
                .HasOne(x => x.KorisnickiNalog)
                .WithMany(x => x.RolesKorisnickiNalog)
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
        public DbSet<TokenPoseta> TokeniPoseta { get; set; }
        public DbSet<Poseta> Posete { get; set; }
        public DbSet<ZdravstvenoStanje> ZdravstvenaStanja { get; set; }
        public DbSet<UputZaLecenje> UputiZaLecenje { get; set; }
        public DbSet<DnevniIzvestaj> DnevniIzvestaji { get; set; }
        public DbSet<CustomIzvestaj> CustomIzvestaji { get; set; }
    }
}