using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Repositories.Contract
{
    public  interface ICartRepositery
    {


        Task<customerCart?> getCartAsync(string cartId);
        Task<customerCart?> UpdateCartAsync(customerCart cart);
        Task<bool> deleteCartAsync(string cartId);
        Task<customerCart?> AddCartItem(string cartId,CartItem item);
        Task<customerCart?> UpdateCartItemAsync(string cartId,CartItem cartItem);
        Task<customerCart?> DeleteCartItemAsync(string cartId, CartItem cartItem);
        
    
    }
}
