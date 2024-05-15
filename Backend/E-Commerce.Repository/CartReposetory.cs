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
            var createdOrUpdated= await _db.StringSetAsync(cart.Id, JsonSerializer.Serialize<customerCart>(cart), TimeSpan.FromDays(30));
            if(!createdOrUpdated)
                return null;
            return await getCartAsync(cart.Id);
        }
        public async Task<customerCart?> AddCartItem(string cartId, CartItem item)
        {
       
            var cart=await getCartAsync(cartId);
            if (cart==null)
            {
                cart=new customerCart(cartId);
                await UpdateCartAsync(cart);
                await AddCartItem(cartId, item);

            }
            foreach(var Item in cart.Items)
            {
                if (Item.Id == item.Id)
                {
                   await UpdateCartItemAsync(cartId, item);
                }
            }
            cart.Items.Add(item);

            return await UpdateCartAsync(cart);
            



        }

        public async Task<customerCart?> UpdateCartItemAsync(string cartId, CartItem cartItem)
        {
            var cart = await getCartAsync(cartId);

            // Exit early if cart is null
            if (cart == null)
            {
                return null;
            }

            // Find the item in the cart
            var itemToUpdate = cart.Items.FirstOrDefault(item => item.Id == cartItem.Id);

            // Update the quantity if item is found
            if (itemToUpdate != null)
            {
                itemToUpdate.Quentity = cartItem.Quentity;
                return await UpdateCartAsync(cart);
            }

            // Return null if item is not found
            return null;
        }

        public async Task<customerCart?> DeleteCartItemAsync(string cartId, CartItem cartItem)
        {
            var cart = await getCartAsync(cartId);

            // Exit early if cart is null
            if (cart == null)
            {
                return null;
            }
            foreach(var item in cart.Items)
            {
                if (item.Id == cartItem.Id)
                {
                    cart.Items.Remove(item);
                    return await UpdateCartAsync(cart);


                }
            }
            return null;

        }
    }
}
