﻿using System;
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICRUDService<ZdravstvenoStanje, ZdravstvenoStanjeDto,ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>, ZdravstvenoStanjeService>();
            services.AddScoped<ICRUDService<Role, TwoFieldsDto,TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto>, RoleService>();
            services.AddScoped<ICRUDService<TokenPoseta, TokenPosetaDto,TokenPosetaDto, TokenPosetaResourceParameters, TokenPosetaUpsertDto, TokenPosetaUpsertDto>, TokenPosetaService>();
            services
                .AddScoped<ICRUDService<Drzava, DrzavaDto,DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest>,
                    DrzavaService>();

            services.AddScoped<ICRUDService<Grad, GradDto,GradDtoEagerLoaded, GradResourceParameters, GradUpsertDto, GradUpsertDto>, GradService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services
                .AddScoped<ICRUDService<LicniPodaci, LicniPodaciDto,LicniPodaciDtoEagerLoaded, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto>, LicniPodaciService>();

            services.AddScoped<ICRUDService<StacionarnoOdeljenje, TwoFieldsDto,TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>, StacionarnoOdeljenjeService>();
            services
                .AddScoped<ICRUDService<RoleKorisnickiNalog, RoleKorisnickiNalogDto,RoleKorisnickiNalogDto, KorisnickiNalogRoleResourceParameters,
                    KorisnickiNalogRoleUpsertDto, KorisnickiNalogRoleUpsertDto>, RoleKorisnikService>();
            services
                .AddScoped<ICRUDService<Radnik, RadnikDtoLazyLoaded,RadnikDtoEagerLoaded, RadnikResourceParameters, RadnikUpsertDto,
                    RadnikUpsertDto>, RadnikService>();

            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
            services.AddTransient<IPropertyMappingService,PropertyMappingService>();
        }
    }
}