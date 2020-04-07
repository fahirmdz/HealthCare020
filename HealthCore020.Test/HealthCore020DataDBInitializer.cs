using HealthCare020.Core.Entities;
using HealthCare020.Repository;

namespace HealthCore020.Test
{
    public class HealthCore020DataDBInitializer
    {
        public HealthCore020DataDBInitializer()
        {
            
        }

        public void Seed(HealthCare020DbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.ZdravstvenaStanja.AddRange(
                new ZdravstvenoStanje {Opis="TestOpis1" },
                new ZdravstvenoStanje {Opis="TestOpis2" },
                new ZdravstvenoStanje {Opis="TestOpis3" },
                new ZdravstvenoStanje {Opis="TestOpis4" },
                new ZdravstvenoStanje {Opis="TestOpis5" },
                new ZdravstvenoStanje {Opis="TestOpis6" }
            );

            context.SaveChanges();
        }
    }
}