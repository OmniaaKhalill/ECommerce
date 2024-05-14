using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : BaseApiController
    {
        private readonly ISellerRepository sellerRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public SellersController(ISellerRepository sellerRepo, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.sellerRepo = sellerRepo;
            this._userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
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



        [HttpPost("AddSeller")]
        public async Task<ActionResult<SellerDto>> addSeller(SellerDto model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);


            if (user == null)
            {
                return NotFound(new { Message = "User Not Found", StatusCode = 404 });

            }

            var seller = new Seller()
            {
                name = user.UserName,
                IDImgUrl = model.IDImgUrl,
                UserId = user.Id,

            };

            var result = await _roleManager.RoleExistsAsync("seller");
            if (!result)
            {
                var role = new IdentityRole();
                role.Name = "seller";
                await _roleManager.CreateAsync(role);

            }

            await _userManager.AddToRoleAsync(user, "seller");

            var AddedSeller = await sellerRepo.AddAsync(seller);

            model.Name = user.UserName;

            return Ok(model);
        }



        [HttpGet("/GetProducts/:id")]

        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBySeller(string UserId)
        {
             var products = await sellerRepo.GetAllPrpductByUserIdAsync(UserId);

            if (products == null)
            {
                return NotFound(new { Message = "products Not Found", StatusCode = 404 });


            }
            var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductSellerDto>>(products);
               

            return  Ok(mappedProducts);
        }
    


            
       

    }  
}