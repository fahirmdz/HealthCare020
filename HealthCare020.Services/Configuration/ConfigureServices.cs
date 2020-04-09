using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare020.Services.Configuration
{
    public static class ConfigureServices
    {
        public static void AddHealthCare020Services(this IServiceCollection services)
        {
            services.AddSingleton((new MapperConfiguration(cfg => cfg.AddProfile(new Mappers.Mapper())).CreateMapper()));

            services.AddScoped<ICRUDService<ZdravstvenoStanje, TwoFields, TwoFieldsSearchRequest, ZdravstvenoStanjeUpsertRequest, ZdravstvenoStanjeUpsertRequest>, ZdravstvenoStanjeService>();
            services.AddScoped<ICRUDService<Role, TwoFields, TwoFieldsSearchRequest, RoleUpsertRequest, RoleUpsertRequest>, RoleService>();
            services.AddScoped<ICRUDService<TokenPoseta, TwoFields, TwoFieldsSearchRequest, TokenPosetaUpsertRequest, TokenPosetaUpsertRequest>, TokenPosetaService>();
            services
                .AddScoped<ICRUDService<Drzava, DrzavaModel, DrzavaSearchRequest, DrzavaUpsertRequest, DrzavaUpsertRequest>,
                    DrzavaService>();

            services.AddScoped<ICRUDService<Grad, GradModel, GradSearchRequest, GradUpsertRequest, GradUpsertRequest>, GradService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services
                .AddScoped<ICRUDService<LicniPodaci, LicniPodaciModel, LicniPodaciSearchRequest, LicniPodaciUpsertRequest, LicniPodaciUpsertRequest>, LicniPodaciService>();
        }
    }
}