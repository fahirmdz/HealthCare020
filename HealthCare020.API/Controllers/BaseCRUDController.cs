using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HealthCare020.API.Controllers
{
    public class BaseCRUDController<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> : BaseController<TEntity, TDto, TDtoEagerLoaded, TResourceParameters>
        where TResourceParameters : BaseResourceParameters
        where TDtoForUpdate : class
    {
        private readonly ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> _crudService;

        public BaseCRUDController(ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> crudService)
            : base(crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TDtoForCreation dtoForCreation)
        {
            var result = await _crudService.Insert(dtoForCreation);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TDtoForUpdate dtoForUpdate)
        {
            var result = await _crudService.Update(id, dtoForUpdate);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _crudService.Delete(id);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<TDtoForUpdate> patchDocument)
        {
            var dtoForUpdate = await _crudService.GetAsUpdateDto(id);

            patchDocument.ApplyTo(dtoForUpdate,ModelState);

            if (!TryValidateModel(dtoForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            var result = await _crudService.Update(id, dtoForUpdate);

            return Ok(result);
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow","GET, POST, PUT, DELETE, OPTIONS");
            return Ok();
        }


        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();

            return (ActionResult) options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}