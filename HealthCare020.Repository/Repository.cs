using HealthCare020.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HealthCare020.Core;

namespace HealthCare020.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly HealthCare020DbContext _dbContext;

        public Repository(HealthCare020DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Type TypeofT()
        {
            return typeof(T);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await _dbContext.Set<T>().Where(filter).ToListAsync();

            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithEagerLoad(string[] children, Expression<Func<T, bool>> filter = null)
        {
            try
            {
                IQueryable<T> query = _dbContext.Set<T>();
                foreach (var x in children)
                {
                    query = query.Include(x);
                }

                if (filter != null)
                    return await query.Where(filter).ToListAsync();
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<T> GetByIdWithEagerLoad(Expression<Func<T, bool>> filter, string[] children)
        {
            try
            {
                IQueryable<T> query = _dbContext.Set<T>();
                foreach (var x in children)
                {
                    query = query.Include(x);
                }
                return await query.FirstOrDefaultAsync(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Insert(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task DeleteById(int id)
        {
            var entity = await GetById(id);
            _dbContext.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}