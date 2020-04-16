using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HealthCare020.Services.Configuration
{
    public static class ConfigureServices
    {
        public static void AddHealthCare020Services(this IServiceCollection services)
        {
            services.AddSingleton((new MapperConfiguration(cfg => cfg.AddProfile(new Mappers.Mapper())).CreateMapper()));

            services.AddScoped<ICRUDService<ZdravstvenoStanje, TwoFieldsDto, TwoFieldsResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>, ZdravstvenoStanjeService>();
            services.AddScoped<ICRUDService<Role, TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto>, RoleService>();
            services.AddScoped<ICRUDService<TokenPoseta, TwoFieldsDto, TwoFieldsResourceParameters, TokenPosetaUpsertDto, TokenPosetaUpsertDto>, TokenPosetaService>();
            services
                .AddScoped<ICRUDService<Drzava, DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest>,
                    DrzavaService>();

            services.AddScoped<ICRUDService<Grad, GradDto, GradResourceParameters, GradUpsertDto, GradUpsertDto>, GradService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services
                .AddScoped<ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto>, LicniPodaciService>();

            services.AddScoped<ICRUDService<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>, StacionarnoOdeljenjeService>();
            services
                .AddScoped<ICRUDService<RoleKorisnickiNalog, RoleKorisnickiNalogDto, KorisnickiNalogRoleResourceParameters,
                    KorisnickiNalogRoleUpsertDto, KorisnickiNalogRoleUpsertDto>, RoleKorisnikService>();
            services
                .AddScoped<ICRUDService<Radnik, RadnikDto, RadnikResourceParameters, RadnikUpsertDto,
                    RadnikUpsertDto>, RadnikService>();

            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
            services.AddTransient<IPropertyMappingService,PropertyMappingService>();
        }
    }
}