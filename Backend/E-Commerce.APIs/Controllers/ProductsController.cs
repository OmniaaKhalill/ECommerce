using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using E_Commerce.Core.Specifications.PageSpecifications;
using E_Commerce.Core.Specifications.ProductSpecs;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public ProductsController(
            IUnitOfWork unit,
            IMapper mapper
            )
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await unit.ProductRepo.GetSpecAsync(spec);

            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(mapper.Map<Product, ProductToReturnDto>(product));
        }


        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(Product product, string UserId)
        {
            var seller = await unit.SellerRepo.GetSellerByUserId(UserId);
            if (seller == null)
            {
                return NotFound(new { Message = "Seller not found", StatusCode = 404 });
            }
            else
            {
                product.SellerId = seller.id;
                product.seller = seller;
                var addedProduct = await unit.ProductRepo.AddAsync(product);

                seller.ProductList ??= new List<Product>();
                seller.ProductList.Add(addedProduct);
                await unit.SellerRepo.UpdateAsync(seller.id, seller);

                var productToReturnDto = mapper.Map<Product, ProductToReturnDto>(addedProduct);
                return Ok(productToReturnDto);
            }
        }

     
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product productDto)
        {
            if (id <= 0)
                return BadRequest(new { Message = "Invalid product ID", StatusCode = "400" });
            productDto.id = id;
            var existingProduct = await unit.ProductRepo.GetAsync(id);


            var updatedProduct = await unit.ProductRepo.UpdateAsync(id, productDto);

            //var updatedDto = mapper.Map<Product, ProductToReturnDto>(updatedProduct);

            return Ok(updatedProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await unit.ProductRepo.GetSpecAsync(spec);
            if (product == null)
            {
                return NotFound();
            }

            await unit.ProductRepo.DeleteAsync(id);

            return NoContent();
        }

        #region Pagination
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductswithPagination([FromQuery] ProductWithPaginationSpecParams specParams)
        {
            var spec = new ProductWithPagination(specParams);
            var products = await unit.ProductRepo.GetAllSpecAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductsWithFilterationForCountSpecifications(specParams);
            var count = await unit.ProductRepo.GetCount(countSpec);
            return Ok(new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize, count, data));
        }
        #endregion


        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductsByCategory(int categoryId)
        {
           
            var category = await unit.CategoryRepo.GetAsync(categoryId);
            if (category == null)
            {
                return NotFound(new { Message = "Category not found", StatusCode = 404 });
            }

            var spec = new ProductSpecifications(categoryId, true);

            var products = await unit.ProductRepo.GetAllSpecAsync(spec);


            var productsToReturn = mapper.Map<List<Product>, List<ProductToReturnDto>>(products.ToList());

      
            return Ok(productsToReturn);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetRandomProducts()
        {
            var spec = new ProductSpecifications();
            var products = await unit.ProductRepo.GetAllSpecAsync(spec);

            var productsToReturn = mapper.Map<List<Product>, List<ProductToReturnDto>>(products.ToList());
            return Ok(productsToReturn);
        }

    }
    }

