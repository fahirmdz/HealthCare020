using System;
using System.Threading.Tasks;
using HealthCare020.Core.Entities;

namespace HealthCare020.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CustomIzvestaj> CustomIzvestaji { get; }
        IRepository<DnevniIzvestaj> DnevniIzvestaji { get; }
        IRepository<Doktor> Doktori { get; }
        IRepository<Drzava> Drzave { get; }
        IRepository<Grad> Gradovi { get; }
        IRepository<KorisnickiNalog> KorisnickiNalozi { get; }
        IRepository<LicniPodaci> LicniPodaci { get; }
        IRepository<MedicinskiTehnicar> MedicinskiTehnicari { get; }
        IRepository<NaucnaOblast> NaucneOblasti { get; }
        IRepository<Pacijent> Pacijenti { get; }
        IRepository<Poseta> Posete { get; }
        IRepository<Radnik> Radnici { get; }
        IRepository<RadnikPrijem> RadniciPrijem { get; }
        IRepository<Role> Roles { get; }
        IRepository<RoleKorisnickiNalog> RolesKorisniNalozi { get; }
        IRepository<StacionarnoOdeljenje> StacionarnaOdeljenja { get; }
        IRepository<TokenPoseta> TokeniPoseta { get; }
        IRepository<UputZaLecenje> UputiZaLecenje { get; }
        IRepository<ZdravstvenoStanje> ZdravstvenaStanja { get; }

        Task<int> CompleteAsync();
        void Complete();
        Task DisposeAsync();
    }
}