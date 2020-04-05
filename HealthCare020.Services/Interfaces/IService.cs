using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface IService<TModel, TSearch>
    {
        Task<IList<TModel>> Get(TSearch search);
        Task<TModel> GetById(int id);
    }
}