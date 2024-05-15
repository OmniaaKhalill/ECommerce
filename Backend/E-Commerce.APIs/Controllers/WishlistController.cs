using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : BaseApiController
    {
        private readonly IWishlistRepository wishlistRepo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public WishlistController(IWishlistRepository wishlistRepo, IMapper mapper, IUnitOfWork unit)
        {
            this.wishlistRepo = wishlistRepo;
            this.mapper = mapper;
            this.unit = unit;
        }

        [HttpGet("id")]
        public async Task<ActionResult<customerWishlist>> GetWishlist(string id)
        {
            var wishlist = await wishlistRepo.GetWishlistAsync(id);
            return wishlist ?? new customerWishlist(id);
        }

        [HttpPost]
        public async Task<ActionResult<customerWishlist>> UpdateWishlist(CustomerWishlistDto dto)
        {
            var mappedWishlist = mapper.Map<CustomerWishlistDto, customerWishlist>(dto);
            var newWishlist = await wishlistRepo.UpdateWishlistAsync(mappedWishlist);
            if (newWishlist is null)
                return BadRequest(new ApiResponse(400));
            return Ok(newWishlist);
        }

        [HttpDelete]
        public async Task DeleteWishlist(string id)
        {
            await wishlistRepo.DeleteWishlistAsync(id);
        }
    }
}
