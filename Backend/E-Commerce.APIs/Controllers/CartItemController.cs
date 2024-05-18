using AutoMapper;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{

    public class CartItemController : BaseApiController
    {
        private readonly ICartRepositery cartRepositery;
        IUnitOfWork unit;
        public CartItemController(
            ICartRepositery cartRepositery,
            IUnitOfWork unit)
        {
            this.cartRepositery = cartRepositery;
            this.unit = unit;

        }
        [HttpPost]
        public async Task<ActionResult<customerCart>> AddCartItem(string cartId, CartItem item)
        {

            if (unit.ProductRepo.GetAsync(item.Id) != null)
            {
                var cart = await cartRepositery.AddCartItem(cartId, item);
                if (cart !=null)
                {
                    return Ok(cart);

                }
                return Ok("you can not add more than 10");


            }
            else
            {
                return BadRequest("you cannot add product that doesnot exist");
            }

        }
        [HttpDelete("{cartId}")]
        public async Task<ActionResult<customerCart>> DeleteCartItem(string cartId, [FromBody] CartItem item)
        {
            var cart = await cartRepositery.DeleteCartItemAsync(cartId, item);
            if (cart != null)
            {
                return Ok(cart);
            }
            return BadRequest(400);

        }
        [HttpPatch("{cartId}")]
        public async Task<ActionResult<customerCart>> UpdateCartItemQuentity(string cartId, CartItem item)
        {
        
            var cart=await cartRepositery.updateItemQuentity(cartId, item);
            if (cart != null)
            {
                return Ok(cart);
            }
            return BadRequest(400);


        }


    }

}
