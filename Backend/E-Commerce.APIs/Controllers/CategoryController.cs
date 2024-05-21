using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications.ProductSpecs;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> CategoryRepo;
        private readonly IMapper mapper;

        public CategoryController(IGenericRepository<Category> CategoryRepo, IMapper mapper)
        {

            this.CategoryRepo = CategoryRepo;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {

            IReadOnlyList<Category> categories = await CategoryRepo.GetAllAsync();
            return Ok(categories);
        }



    }
}
