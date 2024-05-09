using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using E_Commerce.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.APIs.Controllers
{
    public class GenericReposity<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _dbcontext;
        public GenericReposity(ProjectContext dbcontext) {
            _dbcontext = dbcontext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }


        public async Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<T?> GetSpecAsync(ISpecifications<T> spec)
        {

            return await ApplySpecifications(spec).FirstOrDefaultAsync();

        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationsEvalutor<T>.GetQuery(_dbcontext.Set<T>(), spec);
        }

        public async Task<int> GetCount(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity == null)
                return false;

            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<T?> UpdateAsync(int id, T entityToUpdate)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbcontext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
                await _dbcontext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T?> AddAsync(T entity)
        {
           await _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
            
        }
    }
}
