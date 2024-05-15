using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using E_Commerce.Core.Specifications.ProductSpecs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<Seller> sellerRepo;
        private readonly IMapper mapper;

        public ProductsController(
            IGenericRepository<Product> productRepo,
            IGenericRepository<Seller> sellerRepo,
            IMapper mapper
            )
        {
            this.productRepo = productRepo;
            this.sellerRepo = sellerRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductSpecifications(specParams);
            var products = await productRepo.GetAllSpecAsync(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await productRepo.GetSpecAsync(spec);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(mapper.Map<Product, ProductToReturnDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(Product product, int sellerId)
        {
            var seller = await sellerRepo.GetAsync(sellerId);
            if (seller == null)
            {
                return NotFound(new { Message = "Seller not found", StatusCode = 404 });
            }
            else
            {
                product.SellerId = sellerId;
                product.seller = seller;
                var addedProduct = await productRepo.AddAsync(product);

                seller.ProductList ??= new List<Product>();
                seller.ProductList.Add(addedProduct);
                await sellerRepo.UpdateAsync(sellerId, seller);

                var productToReturnDto = mapper.Map<Product, ProductToReturnDto>(addedProduct);
                return Ok(productToReturnDto);
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductToReturnDto productDto)
        {
            if (id <= 0)
                return BadRequest(new { Message = "Invalid product ID", StatusCode = "400" });

            var existingProduct = await productRepo.GetAsync(id);

            if (existingProduct == null)
                return NotFound(new { Message = "Product not found", StatusCode = "404" });

            mapper.Map(productDto, existingProduct);

            var updatedProduct = await productRepo.UpdateAsync(id, existingProduct);

            var updatedDto = mapper.Map<Product, ProductToReturnDto>(updatedProduct);

            return Ok(updatedDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await productRepo.GetSpecAsync(spec);
            if (product == null)
            {
                return NotFound();
            }

            await productRepo.DeleteAsync(id);

            return NoContent();
        }

    }
}
