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
    public class GenericRepoUser<T> : IGenericRepositoryUser<T> where T : IdentityUser
    {

        private readonly ProjectContext _dbcontext;
        public GenericRepoUser(ProjectContext dbcontext)
        {
            _dbcontext = dbcontext;
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
    }
}
