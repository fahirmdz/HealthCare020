using System;
using System.Threading.Tasks;
using HealthCare020.Core.Entities;
using HealthCare020.Repository.Interfaces;

namespace HealthCare020.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly HealthCare020DbContext _dbContext;

        private bool _disposed = false;

        public UnitOfWork(HealthCare020DbContext dbContext,
            IRepository<CustomIzvestaj> customIzvestaji,
            IRepository<DnevniIzvestaj> dnevniIzvestaji,
            IRepository<Doktor> doktori, 
            IRepository<Drzava> drzave, 
            IRepository<Grad> gradovi, 
            IRepository<KorisnickiNalog> korisnickiNalozi, 
            IRepository<LicniPodaci> licniPodaci,
            IRepository<MedicinskiTehnicar> medicinskiTehnicari,
            IRepository<NaucnaOblast> naucneOblasti, 
            IRepository<Pacijent> pacijenti, 
            IRepository<Poseta> posete,
            IRepository<Radnik> radnici,
            IRepository<RadnikPrijem> radniciPrijem, 
            IRepository<Role> roles,
            IRepository<RoleKorisnickiNalog> rolesKorisniNalozi,
            IRepository<StacionarnoOdeljenje> stacionarnaOdeljenja,
            IRepository<TokenPoseta> tokeniPoseta,
            IRepository<UputZaLecenje> uputiZaLecenje,
            IRepository<ZdravstvenoStanje> zdravstvenaStanja)
        {
            _dbContext = dbContext;
            CustomIzvestaji = customIzvestaji;
            DnevniIzvestaji = dnevniIzvestaji;
            Doktori = doktori;
            Drzave = drzave;
            Gradovi = gradovi;
            KorisnickiNalozi = korisnickiNalozi;
            LicniPodaci = licniPodaci;
            MedicinskiTehnicari = medicinskiTehnicari;
            NaucneOblasti = naucneOblasti;
            Pacijenti = pacijenti;
            Posete = posete;
            Radnici = radnici;
            RadniciPrijem = radniciPrijem;
            Roles = roles;
            RolesKorisniNalozi = rolesKorisniNalozi;
            StacionarnaOdeljenja = stacionarnaOdeljenja;
            TokeniPoseta = tokeniPoseta;
            UputiZaLecenje = uputiZaLecenje;
            ZdravstvenaStanja = zdravstvenaStanja;
        }
        public IRepository<CustomIzvestaj> CustomIzvestaji { get; }
        public IRepository<DnevniIzvestaj> DnevniIzvestaji { get; }
        public IRepository<Doktor> Doktori { get; }
        public IRepository<Drzava> Drzave { get; }
        public IRepository<Grad> Gradovi { get; }
        public IRepository<KorisnickiNalog> KorisnickiNalozi { get; }
        public IRepository<LicniPodaci> LicniPodaci { get; }
        public IRepository<MedicinskiTehnicar> MedicinskiTehnicari { get; }
        public IRepository<NaucnaOblast> NaucneOblasti { get; }
        public IRepository<Pacijent> Pacijenti { get; }
        public IRepository<Poseta> Posete { get; }
        public IRepository<Radnik> Radnici { get; }
        public IRepository<RadnikPrijem> RadniciPrijem { get; }
        public IRepository<Role> Roles { get; }
        public IRepository<RoleKorisnickiNalog> RolesKorisniNalozi { get; }
        public IRepository<StacionarnoOdeljenje> StacionarnaOdeljenja { get; }
        public IRepository<TokenPoseta> TokeniPoseta { get; }
        public IRepository<UputZaLecenje> UputiZaLecenje { get; }
        public IRepository<ZdravstvenoStanje> ZdravstvenaStanja { get; }
        public async Task<int> CompleteAsync()
        {
            return !_disposed? await _dbContext.SaveChangesAsync(): 0;
        }

        public void Complete()
        {
            if (!_disposed)
                _dbContext.SaveChanges();
        }

        public async Task DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                _dbContext?.Dispose();
                this._disposed = true;
            }
        }
        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                if (_dbContext != null)
                    await _dbContext.DisposeAsync();
            }
        }
    }
}