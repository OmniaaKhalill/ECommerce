using E_Commerce.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public interface IGenericRepositoryUser<T> where T : IdentityUser  
    {

        Task<T?> UpdateAsync(int id, T entityToUpdate);

    }
}
