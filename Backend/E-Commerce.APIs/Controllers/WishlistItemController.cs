using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistItemController : ControllerBase
    {

        private readonly IWishlistRepository repo;
        private readonly IUnitOfWork unit;

        public WishlistItemController(IWishlistRepository repo, IUnitOfWork unit)
        {
            this.repo = repo;
            this.unit = unit;
        }

        //[HttpPost]
        //public async Task<ActionResult<CustomerWishlist>> AddWishlistItem([FromQuery] string wishlistId, [FromBody] WishlistItem item)
        //{
        //    var product = await unit.ProductRepo.GetAsync(item.Id);
        //    if (product != null)
        //    {
        //        var wishlist = await repo.AddWishlistItem(wishlistId, item);
        //        if (wishlist != null)
        //        {
        //            return Ok(wishlist);
        //        }
        //        else
        //        {
        //            return StatusCode(500, "An error occurred while updating the wishlist.");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("You cannot add a product that does not exist.");
        //    }
        //}



        //[HttpDelete]
        //public async Task<ActionResult<CustomerWishlist>> DeleteWishlistItem(string wishlistId, WishlistItem item)
        //{
        //    var wishlist = await repo.DeleteWishlistItemAsync(wishlistId, item);
        //    if (wishlist != null)
        //    {
        //        return Ok(wishlist);
        //    }
        //    return BadRequest("The item could not be deleted.");
        //}

        //[HttpPost]
        //public async Task<ActionResult<CustomerWishlist>> AddWishlistItem([FromQuery] string wishlistId, [FromBody] WishlistItem item)
        //{
        //    var product = await unit.ProductRepo.GetAsync(item.Id);
        //    if (product != null)
        //    {
        //        var wishlist = await repo.AddWishlistItem(wishlistId, item);
        //        if (wishlist != null)
        //        {
        //            return Ok(wishlist);
        //        }
        //        else
        //        {
        //            return StatusCode(500, "An error occurred while updating the wishlist.");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("You cannot add a product that does not exist.");
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<CustomerWishlist>> AddWishlistItem([FromQuery] string wishlistId, [FromBody] WishlistItem item)
        {
            if (string.IsNullOrWhiteSpace(wishlistId))
            {
                return BadRequest("wishlistId cannot be null or empty.");
            }

            var product = await unit.ProductRepo.GetAsync(item.Id);
            if (product != null)
            {
                var wishlist = await repo.AddWishlistItem(wishlistId, item);
                if (wishlist != null)
                {
                    return Ok(wishlist);
                }
                else
                {
                    return StatusCode(500, "An error occurred while updating the wishlist.");
                }
            }
            else
            {
                return BadRequest("You cannot add a product that does not exist.");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<CustomerWishlist>> DeleteWishlistItem([FromQuery] string wishlistId, [FromBody] WishlistItem item)
        {
            var wishlist = await repo.DeleteWishlistItemAsync(wishlistId, item);
            if (wishlist != null)
            {
                return Ok(wishlist);
            }
            return BadRequest("The item could not be deleted.");
        }


    }


