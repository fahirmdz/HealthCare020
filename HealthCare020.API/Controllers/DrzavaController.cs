﻿using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/"+Routes.DrzaveRoute)]
    public class DrzavaController : BaseCRUDController<Drzava,DrzavaDto,DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest>
    {
        public DrzavaController(ICRUDService<Drzava, DrzavaDto, DrzavaDto, DrzavaResourceParameters, DrzavaUpsertRequest, DrzavaUpsertRequest> crudService) : base(crudService)
        {
        }
    }
}