using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HealthCare020.Core.ResourceParameters;

namespace HealthCare020.API.Controllers
{
    public class BaseCRUDController<TEntity, TDto,TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> : BaseController<TEntity, TDto,TDtoEagerLoaded, TResourceParameters> where TResourceParameters: BaseResourceParameters
    {
        private readonly ICRUDService<TEntity, TDto,TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> _crudService;

        public BaseCRUDController(ICRUDService<TEntity, TDto, TDtoEagerLoaded, TResourceParameters, TDtoForCreation, TDtoForUpdate> crudService)
            :base(crudService)
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

        
    }
}