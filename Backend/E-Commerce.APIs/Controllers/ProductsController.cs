using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.APIs.Helpers;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using E_Commerce.Core.Specifications.ProductSpecs;
using E_Commerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
        //{
        //    var spec = new ProductSpecifications(specParams);
        //    var products = await unit.ProductRepo.GetAllSpecAsync(spec);
        //    return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        //}

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

        //[HttpPost]
        //public async Task<ActionResult<ProductToReturnDto>> CreateProduct([FromBody] Product product, int sellerId, [FromQuery] List<string> colorNames)
        //{
        //    var seller = await unit.SellerRepo.GetAsync(sellerId);
        //    if (seller == null)
        //    {
        //        return NotFound(new { Message = "Seller not found", StatusCode = 404 });
        //    }
        //    else
        //    {
        //        product.SellerId = sellerId;
        //        product.seller = seller;

        //        // Retrieve or create color entities based on the provided color names
        //        var colors = new List<Coulor>();
        //        foreach (var colorName in colorNames)
        //        {
        //            var existingColor = await unit.ColotRepo.GetByNameAsync(colorName);
        //            if (existingColor != null)
        //            {
        //                colors.Add(existingColor);
        //            }
        //            else
        //            {
        //                var newColor = new Coulor { colour_name = colorName };
        //                await unit.ColotRepo.AddAsync(newColor);
        //                colors.Add(newColor);
        //            }
        //        }

        //        product.Colors = colors;

        //        var addedProduct = await unit.ProductRepo.AddAsync(product);

        //        seller.ProductList ??= new List<Product>();
        //        seller.ProductList.Add(addedProduct);
        //        await unit.SellerRepo.UpdateAsync(sellerId, seller);

        //        var productToReturnDto = mapper.Map<Product, ProductToReturnDto>(addedProduct);
        //        return Ok(productToReturnDto);
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<ProductToReturnDto>> CreateProduct(Product product, int sellerId)
        {
            var seller = await unit.SellerRepo.GetAsync(sellerId);
            if (seller == null)
            {
                return NotFound(new { Message = "Seller not found", StatusCode = 404 });
            }
            else
            {
                product.SellerId = sellerId;
                product.seller = seller;
                var addedProduct = await unit.ProductRepo.AddAsync(product);

                seller.ProductList ??= new List<Product>();
                seller.ProductList.Add(addedProduct);
                await unit.SellerRepo.UpdateAsync(sellerId, seller);

                var productToReturnDto = mapper.Map<Product, ProductToReturnDto>(addedProduct);
                return Ok(productToReturnDto);
            }
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, ProductToUpdateDto productToUpdateDto)
        //{
        //    var product = await unit.ProductRepo.GetAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound(new { Message = "Product not found", StatusCode = "404" });
        //    }

        //    mapper.Map(productToUpdateDto, product);
        //    var updatedProduct = await unit.ProductRepo.UpdateAsync(id, product);
        //    var updatedDto = mapper.Map<Product, ProductToReturnDto>(updatedProduct);
        //    return Ok(updatedDto);
        //}

        //    [HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, ProductToReturnDto productDto)
        //{
        //    if (id <= 0)
        //        return BadRequest(new { Message = "Invalid product ID", StatusCode = "400" });

        //    var existingProduct = await unit.ProductRepo.GetAsync(id);

        //    if (existingProduct == null)
        //        return NotFound(new { Message = "Product not found", StatusCode = "404" });

        //    mapper.Map(productDto, existingProduct);

        //    var updatedProduct = await unit.ProductRepo.UpdateAsync(id, existingProduct);

        //    var updatedDto = mapper.Map<Product, ProductToReturnDto>(updatedProduct);

        //    return Ok(updatedDto);
        //}

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

    }
}
