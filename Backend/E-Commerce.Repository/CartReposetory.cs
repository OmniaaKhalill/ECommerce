using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public class CartReposetory : ICartRepositery
    {
        private readonly IDatabase _db;
        public CartReposetory(IConnectionMultiplexer Redis)//ask clr to inject object implement IConnectionMultiplexerto connect to redis
        {
            _db=Redis.GetDatabase();
        }

     

        public async Task<bool> deleteCartAsync(string cartId)
        {
          return await  _db.KeyDeleteAsync(cartId);
        }

        public async Task<customerCart?> getCartAsync(string cartId)
        {
           var cart= await _db.StringGetAsync(cartId);
            return cart.IsNullOrEmpty?null:JsonSerializer.Deserialize<customerCart>(cart);//the cart object is json
        }

        public async Task<customerCart?> UpdateCartAsync(customerCart cart)
        {
            var createdOrUpdated = await _db.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));
            return createdOrUpdated ? await getCartAsync(cart.Id) : null;
        }
        public async Task<customerCart?> AddCartItem(string cartId, CartItem item)
        {

            var cart = await getCartAsync(cartId) ?? new customerCart(cartId);

            var existingItem = cart.Items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }

            return await UpdateCartAsync(cart);
        }

        public async Task<customerCart?> UpdateCartItemAsync(string cartId, CartItem cartItem)
        {
            var cart = await getCartAsync(cartId);
            if (cart == null) return null;

            var itemToUpdate = cart.Items.FirstOrDefault(item => item.Id == cartItem.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = cartItem.Quantity;
                return await UpdateCartAsync(cart);
            }

            return null;
        }

        public async Task<customerCart?> DeleteCartItemAsync(string cartId, CartItem cartItem)
        {
            var cart = await getCartAsync(cartId);
            if (cart == null) return null;

            var itemToRemove = cart.Items.FirstOrDefault(item => item.Id == cartItem.Id);
            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                return await UpdateCartAsync(cart);
            }

            return null;

        }

        public async Task<customerCart?> updateItemQuentity(string cartId, CartItem cartItem)
        {

            var cart = await getCartAsync(cartId);
            if (cart == null) return null;
            var itemToUpdate = cart.Items.FirstOrDefault(i=>i.Id == cartItem.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = cartItem.Quantity;
                return await UpdateCartAsync(cart);
            }
            return null;
           



        }
    }
}
