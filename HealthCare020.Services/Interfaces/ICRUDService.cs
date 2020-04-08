using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TEntity, TModel,TSearch,TInsert,TUpdate>:IService<TEntity, TModel,TSearch>
    {
        Task<TModel> Insert(TInsert request);

        TModel Update(int id, TUpdate request);

        TModel Delete(int id);
    }
}