using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare020.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);

        Task<IEnumerable<T>> GetAllWithEagerLoad(string[] children, Expression<Func<T, bool>> filter = null);

        Task<T> GetById(int id);

        Task<T> GetByIdWithEagerLoad(Expression<Func<T, bool>> filter, string[] children);

        Task Insert(T entity);

        void Delete(T entity);

        Task DeleteById(int id);

        void Update(T entity);

        Task SaveChangesAsync();

        void SaveChanges();
    }
}