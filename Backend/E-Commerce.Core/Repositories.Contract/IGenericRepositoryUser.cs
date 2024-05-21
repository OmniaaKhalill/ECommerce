using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{

    public interface IGenericRepositoryUser<T> where T : AppUser

    {

        Task<T?> UpdateAsync(string id, T entityToUpdate);

        Task<T?> GetAsync(string id);

         Task SaveChanges();

    }
}
