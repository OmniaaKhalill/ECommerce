using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class GenericRepoUser<T> : IGenericRepositoryUser<T> where T : AppUser
    {

        private readonly ProjectContext _dbcontext;
        public GenericRepoUser(ProjectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T?> GetAsync(string id)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task SaveChanges()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<T?> UpdateAsync(string id, T entityToUpdate)
        {
            T entity = await _dbcontext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbcontext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
                
            }
            return entity;
        }

       
    }
}
