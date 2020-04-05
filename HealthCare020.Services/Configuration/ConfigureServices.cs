using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Repository;
using HealthCare020.Repository.Interfaces;
using HealthCare020.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare020.Services.Configuration
{
    public static class ConfigureServices
    {
        public static void AddHealthCare020Services(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICRUDService<TwoFields,TwoFieldsSearchRequest,ZdravstvenoStanjeUpsertRequest,ZdravstvenoStanjeUpsertRequest>,ZdravstvenoStanjeService>();
        }
    }
}