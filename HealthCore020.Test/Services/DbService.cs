using HealthCare020.Repository;
using HealthCore020.Test.Constants;
using Microsoft.EntityFrameworkCore;

namespace HealthCore020.Test.Services
{
    public class DbService
    {
        private static DbService _dbService = null;

        private static HealthCare020DbContext _dbContext;

        public static DbService Instance
        {
            get
            {
                if (_dbService == null)
                    _dbService = new DbService();
                return _dbService;
            }
        }

        public DbService()
        {
            var dbContextOptions = new DbContextOptionsBuilder<HealthCare020DbContext>().UseSqlServer(DbConstants.ConnectionString).Options;

            _dbContext = new HealthCare020DbContext(dbContextOptions);

            HealthCore020DataDBInitializer db = new HealthCore020DataDBInitializer();
        }

        public HealthCare020DbContext GetDbContext() => _dbContext;
    }
}