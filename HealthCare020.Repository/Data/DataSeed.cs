using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Repository.Data
{
    public class DataSeed
    {
        public static bool Seed(HealthCare020DbContext context)
        {
            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
                return true;
            }

            return false;
        }
    }
}