using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
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
        private readonly IMapper mapper;

        public ProductsController(
            IGenericRepository<Product> productRepo,
            IMapper mapper
            )
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductSpecifications();
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
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(ProductToCreateDto productToCreateDto)
        {
            var product = mapper.Map<ProductToCreateDto, Product>(productToCreateDto);
            await productRepo.AddAsync(product);
            var productToReturnDto = mapper.Map<Product, ProductToReturnDto>(product);
            return CreatedAtAction("Added", new { id = product.id }, productToReturnDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductToUpdateDto productToUpdateDto)
        {
            var product = await productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            mapper.Map(productToUpdateDto, product);
            await productRepo.UpdateAsync(id, product);

            return NoContent();


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
