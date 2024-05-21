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
<<<<<<< HEAD
        private readonly IWishlistRepository repo;
        private readonly IUnitOfWork unit;

        public WishlistItemController(IWishlistRepository repo, IUnitOfWork unit)
        {
            this.repo = repo;
            this.unit = unit;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerWishlist>> AddWishlistItem(string wishlistId, WishlistItem item)
        {
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
        public async Task<ActionResult<CustomerWishlist>> DeleteWishlistItem(string wishlistId, WishlistItem item)
        {
            var wishlist = await repo.DeleteWishlistItemAsync(wishlistId, item);
            if (wishlist != null)
            {
                return Ok(wishlist);
            }
            return BadRequest("The item could not be deleted.");
        }

    }
}
=======
        //private readonly IWishlistRepository wishlistRepo;
        //private readonly IUnitOfWork unit;

        //public WishlistItemController(IWishlistRepository wishlistRepo, IUnitOfWork unit)
        //{
        //    this.wishlistRepo = wishlistRepo;
        //    this.unit = unit;
        //}

        //[HttpPost]
        //public async Task<ActionResult<customerWishlist>> AddWishlist(string wishlistId, WishlistItem item)
        //{
        //    if (unit.ProductRepo.GetAsync(item.Id) != null)
        //    {
        //        var wishlist = wishlistRepo.AddWishlistItem(wishlistId, item);
        //        return Ok(wishlist);
        //    }
        //    else
        //    {
        //        return BadRequest("You cannot add Product that does not exist");
        //    }
        //}

        //[HttpDelete]
        //public async Task<ActionResult<customerWishlist>> DeleteWishlistItem(string wishlistId, WishlistItem item)
        //{
        //    var wishlist = wishlistRepo.DeleteWishlistItemAsync(wishlistId, item);
        //    if (wishlist != null)
        //    {
        //        return Ok(wishlist);
        //    }
        //    return BadRequest(400);
        }
    }

>>>>>>> d1feedafe6940e0f064b1a06642e8a8fafa54525
