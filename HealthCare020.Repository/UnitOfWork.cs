using HealthCare020.Core.Entities;
using HealthCare020.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace HealthCare020.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthCare020DbContext _dbContext;

        private IRepository<CustomIzvestaj> _customIzvestaji;
        private IRepository<DnevniIzvestaj> _dnevniIzvestaji;
        private IRepository<Doktor> _doktori;
        private IRepository<Drzava> _drzave;
        private IRepository<Grad> _gradovi;
        private IRepository<KorisnickiNalog> _korisnickiNalozi;
        private IRepository<LicniPodaci> _licniPodaci;
        private IRepository<MedicinskiTehnicar> _medicinskiTehnicari;
        private IRepository<NaucnaOblast> _naucneOblasti;
        private IRepository<Pacijent> _pacijenti;
        private IRepository<Poseta> _posete;
        private IRepository<Radnik> _radnici;
        private IRepository<RadnikPrijem> _radniciPrijem;
        private IRepository<Role> _roles;
        private IRepository<RoleKorisnickiNalog> _rolesKorisniNalozi;
        private IRepository<StacionarnoOdeljenje> _stacionarnaOdeljenja;
        private IRepository<TokenPoseta> _tokeniPoseta;
        private IRepository<UputZaLecenje> _uputiZaLecenje;
        private IRepository<ZdravstvenoStanje> _zdravstvenaStanja;

        private bool _disposed = false;

        public UnitOfWork(HealthCare020DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Getters
        public IRepository<CustomIzvestaj> CustomIzvestaji
        {
            get { return _customIzvestaji ??= new Repository<CustomIzvestaj>(_dbContext); }
        }

        public IRepository<DnevniIzvestaj> DnevniIzvestaji
        {
            get { return _dnevniIzvestaji ??= new Repository<DnevniIzvestaj>(_dbContext); }
        }

        public IRepository<Doktor> Doktori
        {
            get { return _doktori ??= new Repository<Doktor>(_dbContext); }
        }

        public IRepository<Drzava> Drzave
        {
            get { return _drzave ??= new Repository<Drzava>(_dbContext); }
        }

        public IRepository<Grad> Gradovi
        {
            get { return _gradovi ??= new Repository<Grad>(_dbContext); }
        }

        public IRepository<KorisnickiNalog> KorisnickiNalozi
        {
            get { return _korisnickiNalozi ??= new Repository<KorisnickiNalog>(_dbContext); }
        }

        public IRepository<LicniPodaci> LicniPodaci
        {
            get { return _licniPodaci ??= new Repository<LicniPodaci>(_dbContext); }
        }

        public IRepository<MedicinskiTehnicar> MedicinskiTehnicari
        {
            get { return _medicinskiTehnicari ??= new Repository<MedicinskiTehnicar>(_dbContext); }
        }

        public IRepository<NaucnaOblast> NaucneOblasti
        {
            get { return _naucneOblasti = new Repository<NaucnaOblast>(_dbContext); }
        }

        public IRepository<Pacijent> Pacijenti
        {
            get { return _pacijenti ??= new Repository<Pacijent>(_dbContext); }
        }

        public IRepository<Poseta> Posete
        {
            get { return _posete ??= new Repository<Poseta>(_dbContext); }
        }

        public IRepository<Radnik> Radnici
        {
            get { return _radnici ??= new Repository<Radnik>(_dbContext); }
        }

        public IRepository<RadnikPrijem> RadniciPrijem
        {
            get { return _radniciPrijem ??= new Repository<RadnikPrijem>(_dbContext); }
        }

        public IRepository<Role> Roles
        {
            get { return _roles ??= new Repository<Role>(_dbContext); }
        }

        public IRepository<RoleKorisnickiNalog> RolesKorisniNalozi
        {
            get { return _rolesKorisniNalozi ??= new Repository<RoleKorisnickiNalog>(_dbContext); }
        }

        public IRepository<StacionarnoOdeljenje> StacionarnaOdeljenja
        {
            get { return _stacionarnaOdeljenja ??= new Repository<StacionarnoOdeljenje>(_dbContext); }
        }

        public IRepository<TokenPoseta> TokeniPoseta
        {
            get { return _tokeniPoseta ??= new Repository<TokenPoseta>(_dbContext); }
        }

        public IRepository<UputZaLecenje> UputiZaLecenje
        {
            get { return _uputiZaLecenje ??= new Repository<UputZaLecenje>(_dbContext); }
        }

        public IRepository<ZdravstvenoStanje> ZdravstvenaStanja
        {
            get { return _zdravstvenaStanja ??= new Repository<ZdravstvenoStanje>(_dbContext); }
        }
        #endregion


        public IRepository<T> Set<T>() where T : class
        {
            if (typeof(T) == CustomIzvestaji.TypeofT())
                return (IRepository<T>)CustomIzvestaji;
            if (typeof(T) == DnevniIzvestaji.TypeofT())
                return (IRepository<T>)DnevniIzvestaji;
            if (typeof(T) == Doktori.TypeofT())
                return (IRepository<T>)Doktori;
            if (typeof(T) == Drzave.TypeofT())
                return (IRepository<T>)Drzave;
            if (typeof(T) == Gradovi.TypeofT())
                return (IRepository<T>)Gradovi;
            if (typeof(T) == KorisnickiNalozi.TypeofT())
                return (IRepository<T>)KorisnickiNalozi;
            if (typeof(T) == LicniPodaci.TypeofT())
                return (IRepository<T>)LicniPodaci;
            if (typeof(T) == MedicinskiTehnicari.TypeofT())
                return (IRepository<T>)MedicinskiTehnicari;
            if (typeof(T) == NaucneOblasti.TypeofT())
                return (IRepository<T>)NaucneOblasti;
            if (typeof(T) == Pacijenti.TypeofT())
                return (IRepository<T>)Pacijenti;
            if (typeof(T) == Posete.TypeofT())
                return (IRepository<T>)Posete;
            if (typeof(T) == Radnici.TypeofT())
                return (IRepository<T>)Radnici;
            if (typeof(T) == RadniciPrijem.TypeofT())
                return (IRepository<T>)RadniciPrijem;
            if (typeof(T) == Roles.TypeofT())
                return (IRepository<T>)Roles;
            if (typeof(T) == RolesKorisniNalozi.TypeofT())
                return (IRepository<T>)RolesKorisniNalozi;
            if (typeof(T) == StacionarnaOdeljenja.TypeofT())
                return (IRepository<T>)StacionarnaOdeljenja;
            if (typeof(T) == TokeniPoseta.TypeofT())
                return (IRepository<T>)TokeniPoseta;
            if (typeof(T) == UputiZaLecenje.TypeofT())
                return (IRepository<T>)UputiZaLecenje;
            if (typeof(T) == ZdravstvenaStanja.TypeofT())
                return (IRepository<T>)ZdravstvenaStanja;

            return null;
        }

        public async Task<int> CompleteAsync()
        {
            return !_disposed ? await _dbContext.SaveChangesAsync() : 0;
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