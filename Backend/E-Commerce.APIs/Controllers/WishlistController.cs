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
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistRepository repo;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public WishlistController(
            IWishlistRepository repo,
            IMapper mapper
            )
        {
            this.repo = repo;
            this.mapper = mapper;
            this.unit = unit;
        }

        [HttpGet("id")]
        public async Task<ActionResult<CustomerWishlist>> GetWishlist(string id)
        {
            var wishlist = await repo.GetWishlistAsync(id);
            return wishlist ?? new CustomerWishlist(id);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerWishlist>> UpdateWishlist(CustomerWishlistDto dto)
        {
            var mappedWishlist = mapper.Map<CustomerWishlistDto, CustomerWishlist>(dto);
            var newWishlist = await repo.UpdateWishlistAsync(mappedWishlist);
            if (newWishlist is null)
                return BadRequest(new ApiResponse(400));
            return Ok(newWishlist);
        }

        [HttpDelete]
        public async Task DeleteWishlist(string id)
        {
            await repo.DeleteWishlistAsync(id);
        }
    }
}
