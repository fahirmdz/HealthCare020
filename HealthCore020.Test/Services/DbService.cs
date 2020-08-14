using HealthCare020.Repository;
using HealthCore020.Test.Constants;
using Microsoft.EntityFrameworkCore;

namespace HealthCore020.Test.Services
{
    public class DbService
    {
        private static DbService _dbService;

        private static HealthCare020DbContext _dbContext;

        public static DbService Instance
        {
            get { return _dbService ??= new DbService(); }
        }

        public DbService()
        {
            var dbContextOptions = new DbContextOptionsBuilder<HealthCare020DbContext>().UseSqlServer(DbConstants.ConnectionString).Options;

            _dbContext = new HealthCare020DbContext(dbContextOptions);
        }

        public HealthCare020DbContext GetDbContext() => _dbContext;
    }
}