using System;
using System.Threading.Tasks;
using HealthCare020.API.Constants;
using HealthCare020.Core.Constants;
using HealthCare020.Core.Entities;
using HealthCare020.Core.Models;
using HealthCare020.Core.Request;
using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    [Route("api/" + Routes.PreglediRoute)]
    public class PregledController : BaseCRUDController<Pregled, PregledDtoLL, PregledDtoEL, PregledResourceParameters, PregledUpsertDto, PregledUpsertDto>
    {
        private readonly IPregledService _pregledService;
        public PregledController(ICRUDService<Pregled, PregledDtoLL, PregledDtoEL, PregledResourceParameters, PregledUpsertDto, PregledUpsertDto> crudService) : base(crudService)
        {
            _pregledService=_crudService as PregledService;
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> Get(PregledResourceParameters resourceParameters)
        {
            return await base.Get(resourceParameters);
        }

        [Authorize(AuthorizationPolicies.PacijentPolicy)]
        public override async Task<IActionResult> GetById(int id, bool? EagerLoaded)
        {
            return await base.GetById(id, EagerLoaded);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<PregledUpsertDto> patchDocument)
        {
            return await base.PartiallyUpdate(id, patchDocument);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> Update(int id, PregledUpsertDto dtoForUpdate)
        {
            return await base.Update(id, dtoForUpdate);
        }

        [Authorize(AuthorizationPolicies.MedicinskiTehnicarPolicy)]
        public override async Task<IActionResult> Insert(PregledUpsertDto dtoForCreation)
        {
            return await base.Insert(dtoForCreation);
        }

        [AllowAnonymous]
        [HttpGet("recommend-time")]
        public async Task<IActionResult> GetRecommendedPregledTime([FromQuery] int godiste)
        {
            if (godiste <= 1930 || godiste >= DateTime.Now.Year)
                return BadRequest($"Godiste moze biti u rasponu od 1900 do {DateTime.Now.Year}");
            var recommended = await _pregledService.GetRecommendedVrijemePregleda(godiste);

            return Ok(recommended.ToString("g"));
        }
    }
}