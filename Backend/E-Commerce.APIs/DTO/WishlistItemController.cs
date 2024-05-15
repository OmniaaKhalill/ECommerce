using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistItemController : ControllerBase
    {
        private readonly IWishlistRepository wishlistRepo;
        private readonly IUnitOfWork unit;

        public WishlistItemController(IWishlistRepository wishlistRepo, IUnitOfWork unit)
        {
            this.wishlistRepo = wishlistRepo;
            this.unit = unit;
        }

        [HttpPost]
        public async Task<ActionResult<customerWishlist>> AddWishlist(string wishlistId, WishlistItem item)
        {
            if (unit.ProductRepo.GetAsync(item.Id) != null)
            {
                var wishlist = wishlistRepo.AddWishlistItem(wishlistId, item);
                return Ok(wishlist);
            }
            else
            {
                return BadRequest("You cannot add Product that does not exist");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<customerWishlist>> DeleteWishlistItem(string wishlistId, WishlistItem item)
        {
            var wishlist = wishlistRepo.DeleteWishlistItemAsync(wishlistId, item);
            if (wishlist != null)
            {
                return Ok(wishlist);
            }
            return BadRequest(400);
        }
    }
}
