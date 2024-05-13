using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{

    public class CartController : BaseApiController
    {
        private readonly ICartRepositery cartRepositery;
        IMapper _mapper;
        IUnitOfWork unit;
        public CartController(ICartRepositery cartRepo,IMapper mapper, IUnitOfWork unit)
        {
            cartRepositery = cartRepo;
            _mapper = mapper;
            this.unit = unit;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<customerCart>>getCart(string id)
        {
            var cart=await cartRepositery.getCartAsync(id);
            if(cart == null)
            {
              return Ok(  cart=new customerCart(id));
            }
            return Ok(cart);
        }
        [HttpPost]
        public async Task<ActionResult<customerCart>>updateCart(CustomerCartDto cart)
        {
           var MappedCart= _mapper.Map<CustomerCartDto, customerCart>(cart);
            var createdOrUpdatedCart= await cartRepositery.UpdateCartAsync(MappedCart);
            if(createdOrUpdatedCart == null)
            {
                return BadRequest(new ApiResponse(400));
            }
            return Ok(createdOrUpdatedCart);
        }

        [HttpDelete]
        public async Task DeleteCart(string id)
        {
            await cartRepositery.deleteCartAsync(id);
        }
        [HttpPost("AddCartItem")]
        public async Task<ActionResult<customerCart>> AddCartItem(string id,CartItem item)
        {
            int productId = int.Parse(id);
            if (unit.ProductRepo.GetAsync(productId)!=null)
            {
                var cart = cartRepositery.AddCartItem(id, item);
                return Ok(cart);
            }
            else
            {
                return BadRequest("you cannot add product that doesnot exist");
            }
             
        }



    }
}
