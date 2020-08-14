using HealthCare020.Core.ResourceParameters;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    public class BaseCRUDController<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> : BaseController<TEntity, TResourceParameters>
        where TResourceParameters : BaseResourceParameters
        where TDtoForUpdate : class
    {
        protected readonly ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> _crudService;

        public BaseCRUDController(ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> crudService)
            : base(crudService)
        {
            _crudService = crudService;
        }

        [Authorize]
        [HttpPost]
        public virtual async Task<IActionResult> Insert(TDtoForCreation dtoForCreation)
        {
            var result = await _crudService.Insert(dtoForCreation);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return Ok(result.Data);
        }

        [Authorize]
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TDtoForUpdate dtoForUpdate)
        {
            var result = await _crudService.Update(id, dtoForUpdate);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return Ok(result.Data);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _crudService.Delete(id);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            return NoContent();
        }

        [Authorize]
        [HttpPatch("{id}")]
        public virtual async Task<IActionResult> PartiallyUpdate(int id, JsonPatchDocument<TDtoForUpdate> patchDocument)
        {
            var result = await _crudService.GetAsUpdateDto(id);
            if (!result.Succeeded)
                return WithStatusCode(result.StatusCode, result.Message);

            var dtoForUpdate = result.Data as TDtoForUpdate;

            patchDocument.ApplyTo(dtoForUpdate, ModelState);

            if (!TryValidateModel(dtoForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            var updateResult = await _crudService.Update(id, dtoForUpdate);
            if (!updateResult.Succeeded)
                return WithStatusCode(updateResult.StatusCode, updateResult.Message);

            return Ok(result.Data);
        }

        [HttpOptions]
        public virtual IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
            return Ok();
        }

        [NonAction]
        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();

            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}