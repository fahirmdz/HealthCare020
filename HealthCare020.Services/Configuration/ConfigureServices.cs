using AutoMapper;
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
            services.AddSingleton((new MapperConfiguration(cfg => cfg.AddProfile(new Mappers.Mapper())).CreateMapper()));

            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICRUDService<TwoFields,TwoFieldsSearchRequest,ZdravstvenoStanjeUpsertRequest,ZdravstvenoStanjeUpsertRequest>,ZdravstvenoStanjeService>();
            services.AddScoped<ICRUDService<TwoFields,TwoFieldsSearchRequest,RoleUpsertRequest,RoleUpsertRequest>,RoleService>();
            services.AddScoped<ICRUDService<TwoFields,TwoFieldsSearchRequest,TokenPosetaUpsertRequest,TokenPosetaUpsertRequest>,TokenPosetaService>();
            services
                .AddScoped<ICRUDService<DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>,
                    DrzavaService>();


        }
    }
}