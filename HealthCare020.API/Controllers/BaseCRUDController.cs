using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare020.API.Controllers
{
    public class BaseCRUDController<TEntity, TModel, TSerach, TInsert, TUpdate> : BaseController<TEntity,TModel, TSerach>
    {
        private readonly ICRUDService<TEntity, TModel, TSerach, TInsert, TUpdate> _crudService;

        public BaseCRUDController(ICRUDService<TEntity, TModel, TSerach, TInsert, TUpdate> crudService) : base(crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TInsert request)
        {
            var result = await _crudService.Insert(request);

            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TUpdate request)
        {
            if (_crudService.GetById(id).Result == null)
                return NotFound();

            var result = _crudService.Update(id, request);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _crudService.GetById(id).Result;

            if (entity == null)
                return NotFound();

            var result = _crudService.Delete(id);

            return Ok(result);
        }
    }
}