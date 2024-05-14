using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications.ProductSpecs;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.APIs.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using E_Commerce.Repository;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShopController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        #region Get All Products
        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams specParams)
        //{
        //    var spec = new ProductSpecifications(specParams);
        //    var products = await unitOfWork.ProductRepo.GetAllSpecAsync(spec);
        //    var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        //    var countSpec = new ProductsWithFilterationForCountSpecifications(specParams);
        //    var count = await unitOfWork.ProductRepo.GetCount(countSpec);
        //    return Ok(new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize, count, data));
        //}
        #endregion

        #region Get Product By Id
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductSpecifications(id);
            var products = await unitOfWork.ProductRepo.GetSpecAsync(spec);

            if (products is null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(mapper.Map<Product, ProductToReturnDto>(products));
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductSpecifications();
            var products = await unitOfWork.ProductRepo.GetAllSpecAsync(spec);
            var productList = products.ToList(); // Convert IReadOnlyList to List
            return Ok(mapper.Map<List<Product>, List<ProductToReturnDto>>(productList));
        }

        #region Categories
        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<CategoriesDto>>> GetCategories()
        {
            var categories = await unitOfWork.CategoryRepo.GetAllAsync();
            var categoryList = categories.ToList();
            return Ok(mapper.Map<List<Category>, List<CategoriesDto>>(categoryList));
        }
        

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductsByCategory(int categoryId)
        {
            var category = await unitOfWork.CategoryRepo.GetAsync(categoryId);

            if (category == null)
            {
                return NotFound(new ApiResponse(404, "Category not found"));
            }

            var spec = new ProductSpecifications(categoryId);
            var products = await unitOfWork.ProductRepo.GetAllSpecAsync(spec);

            var productList = products.ToList();
            return Ok(mapper.Map<List<Product>, List<ProductToReturnDto>>(productList));
        }
        #endregion

        #region Brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandsDto>>> GetBrands()
        {
            var brands = await unitOfWork.BrandsRepo.GetAllAsync();
            var brandList = brands.ToList();
            return Ok(mapper.Map<List<Brands>, List<BrandsDto>>(brandList));
        }
        

        [HttpGet("brands/{brandId}")]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProductsByBrand(int brandId)
        {
            var brand = await unitOfWork.BrandsRepo.GetAsync(brandId);

            if (brand == null)
            {
                return NotFound(new ApiResponse(404, "Brand not found"));
            }

            var spec = new ProductSpecifications(brandId);
            var products = await unitOfWork.ProductRepo.GetAllSpecAsync(spec);

            var productList = products.ToList();
            return Ok(mapper.Map<List<Product>, List<ProductToReturnDto>>(productList));
        }
        #endregion
    }
}
