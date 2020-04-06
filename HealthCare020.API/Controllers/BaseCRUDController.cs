using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare020.API.Controllers
{
    public class BaseCRUDController<TModel, TSerach, TInsert, TUpdate> : BaseController<TModel,TSerach>
    {
        private readonly ICRUDService<TModel, TSerach, TInsert, TUpdate> _crudService;

        public BaseCRUDController( ICRUDService<TModel, TSerach, TInsert, TUpdate> crudService) : base(crudService)
        {
            _crudService = crudService;
        }

        [HttpPost]
        public async Task<TModel> Insert(TInsert request)
        {
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public TModel Update(int id, TUpdate request)
        {
            return _crudService.Update(id, request);
        }

        [HttpDelete("{id}")]
        public TModel Delete(int id)
        {
           return _crudService.Delete(id);
        }
    }
}