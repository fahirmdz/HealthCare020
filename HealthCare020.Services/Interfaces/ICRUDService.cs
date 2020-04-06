using System.Threading.Tasks;

namespace HealthCare020.Services.Interfaces
{
    public interface ICRUDService<TModel,TSearch,TInsert,TUpdate>:IService<TModel,TSearch>
    {
        Task<TModel> Insert(TInsert request);

        TModel Update(int id, TUpdate request);

        TModel Delete(int id);
    }
}