using Microsoft.EntityFrameworkCore;

namespace HealthCare020.Repository.Data
{
    public class DataSeed
    {
        public static void Seed(HealthCare020DbContext context)
        {
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }
    }
}