using AutoMapper;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using HealthCare020.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HealthCare020.Services.Configuration
{
    public static class ConfigureServices
    {
        public static void AddHealthCare020Services(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISecurityService, SecurityService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICRUDService<ZdravstvenoStanje, ZdravstvenoStanjeDto, ZdravstvenoStanjeDto, ZdravstvenoStanjeResourceParameters, ZdravstvenoStanjeUpsertDto, ZdravstvenoStanjeUpsertDto>, ZdravstvenoStanjeService>();
            services.AddScoped<ICRUDService<Role, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, RoleUpsertDto, RoleUpsertDto>, RoleService>();
            services.AddScoped<ICRUDService<NaucnaOblast, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, NaucnaOblastUpsertDto, NaucnaOblastUpsertDto>, NaucnaOblastService>();
            services
                .AddScoped<ICRUDService<Drzava, DrzavaDto, DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest>,
                    DrzavaService>();

            services.AddScoped<ICRUDService<Grad, GradDtoLL, GradDtoEL, GradResourceParameters, GradUpsertDto, GradUpsertDto>, GradService>();
            services.AddScoped<IKorisnikService, KorisnikService>();
            services
                .AddScoped<ICRUDService<KorisnickiNalog, KorisnickiNalogDtoLL, KorisnickiNalogDtoEL,
                        KorisnickiNalogResourceParameters, KorisnickiNalogUpsertDto, KorisnickiNalogUpsertDto>,
                    KorisnikService>();
            services
                .AddScoped<ICRUDService<LicniPodaci, LicniPodaciDto, LicniPodaciDto, LicniPodaciResourceParameters, LicniPodaciUpsertDto, LicniPodaciUpsertDto>, LicniPodaciService>();

            services.AddScoped<ICRUDService<StacionarnoOdeljenje, TwoFieldsDto, TwoFieldsDto, TwoFieldsResourceParameters, StacionarnoOdeljenjeUpsertDto, StacionarnoOdeljenjeUpsertDto>, StacionarnoOdeljenjeService>();
            services
                .AddScoped<ICRUDService<RadnikPrijem, RadnikPrijemDtoLL, RadnikPrijemDtoEL, RadnikPrijemResourceParameters, RadnikPrijemUpsertDto,
                    RadnikPrijemUpsertDto>, RadnikPrijemService>();
            services
                .AddScoped<ICRUDService<MedicinskiTehnicar, MedicinskiTehnicarDtoLL, MedicinskiTehnicarDtoEL, MedicinskiTehnicarResourceParameters, MedicinskiTehnicarUpsertDto,
                    MedicinskiTehnicarUpsertDto>, MedicinskiTehnicarService>();
            services
                .AddScoped<ICRUDService<Doktor, DoktorDtoLL, DoktorDtoEL, DoktorResourceParameters, DoktorUpsertDto,
                    DoktorUpsertDto>, DoktorService>();

            services
                .AddScoped<ICRUDService<Pacijent, PacijentDtoLL, PacijentDtoEL, PacijentResourceParameters,
                    PacijentUpsertDto, PacijentUpsertDto>, PacijentService>();

            services
                .AddScoped<ICRUDService<ZahtevZaPregled, ZahtevZaPregledDtoLL, ZahtevZaPregledDtoEL,
                        ZahtevZaPregledResourceParameters, ZahtevZaPregledUpsertDto, ZahtevZaPregledUpsertDto>,
                    ZahtevZaPregledService>();

            services
                .AddScoped<ICRUDService<Pregled, PregledDtoLL, PregledDtoEL, PregledResourceParameters, PregledUpsertDto
                    , PregledUpsertDto>, PregledService>();

            services
                .AddScoped<ICRUDService<ZdravstvenaKnjizica, ZdravstvenaKnjizicaDtoLL, ZdravstvenaKnjizicaDtoEL,
                        ZdravstvenaKnjizicaResourceParameters, ZdravstvenaKnjizicaUpsertDto,
                        ZdravstvenaKnjizicaUpsertDto>,
                    ZdravstvenaKnjizicaService>();

            services
                .AddScoped<ICRUDService<ZahtevZaPosetu, ZahtevZaPosetuDtoLL, ZahtevZaPosetuDtoEL,
                        ZahtevZaPosetuResourceParameters, ZahtevZaPosetuUpsertDto, ZahtevZaPosetuUpsertDto>,
                    ZahtevZaPosetuService>();

            services.AddScoped<ICRUDService<PacijentNaLecenju, PacijentNaLecenjuDtoLL, PacijentNaLecenjuDtoEL,
               PacijentNaLecenjuResourceParameters, PacijentNaLecenjuUpsertDto, PacijentNaLecenjuUpsertDto>
                , PacijentNaLecenjuService>();

            services.AddScoped<
                ICRUDService<LekarskoUverenje, LekarskoUverenjeDtoLL, LekarskoUverenjeDtoEL,
                    LekarskoUverenjeResourceParameters, LekarskoUverenjeUpsertDto, LekarskoUverenjeUpsertDto>,
                LekarskoUverenjeService>();

            services.AddScoped<IRadnikService, RadnikService>();

            services.AddTransient<IPropertyCheckerService, PropertyCheckerService>();
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
        }
    }
}