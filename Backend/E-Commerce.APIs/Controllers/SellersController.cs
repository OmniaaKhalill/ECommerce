using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : BaseApiController
    {
        private readonly IGenericRepository<Seller> sellerRepo;

        public SellersController(IGenericRepository<Seller> sellerRepo)
        {
            this.sellerRepo = sellerRepo;
        }

        [HttpPost("img/{sellerId}")]
        public async Task<IActionResult> UploadIdImage(int sellerId, [FromBody] string idImgUrl)
        {
            var spec = new SellerSpec(sellerId);
            var seller = await sellerRepo.GetSpecAsync(spec);
            if (seller == null)
            {
                return NotFound("Seller not found");
            }

            seller.IDImgUrl = idImgUrl;
            await sellerRepo.UpdateAsync(sellerId, seller);

            return Ok("Uploaded successfully");
        }

    }
}
