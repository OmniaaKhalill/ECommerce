using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications.PageSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
  
    public class PageController : BaseApiController
    {

        private readonly IGenericRepository<Page> _pageRepo;
        private readonly IMapper _mapper;

        public PageController(IGenericRepository<Page> pageRepo, IMapper mapper)
        {
            _pageRepo = pageRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]   //get all products list missing because the model of page don't contain list<products>
        public async Task<ActionResult<PageToReturnDto>> GetPage(int id)
        {

            var spec = new PageSpec(id);
            var page = await _pageRepo.GetSpecAsync(spec);
            if (page is null)
                return NotFound(new { Message = "not found page", StatusCode = "404" });

            return Ok(_mapper.Map<Page, PageToReturnDto>(page));
        }
        [HttpGet("seller/{sellerId}")]
        public async Task<ActionResult<PageToReturnDto>> GetPageBySellerId(int sellerId)
        {
            if (sellerId == null)
                return NotFound(new { Message = "not found seller", StatusCode = "404" });
            else
            {
                var spec = new PageSpec(sellerId,true);
                var page = await _pageRepo.GetSpecAsync(spec);
                if (page is null)
                    return NotFound(new { Message = "not found page", StatusCode = "404" });

                return Ok(_mapper.Map<Page, PageToReturnDto>(page));
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePage(int id)
        {
            if (id <= 0)
                return BadRequest(new { Message = "Invalid page ID", StatusCode = "400" });

            bool deleted = await _pageRepo.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { Message = "Page not found", StatusCode = "404" });

            return NoContent();  
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<PageToReturnDto>> UpdatePage(int id, Page entity)
        {
            if (id <= 0)
                return BadRequest(new { Message = "Invalid page ID", StatusCode = "400" });

            var updatedPage = await _pageRepo.UpdateAsync(id, entity);
            if (updatedPage == null)
                return NotFound(new { Message = "Page not found", StatusCode = "404" });

            var updatedDto = _mapper.Map<Page, PageToReturnDto>(updatedPage);
            return updatedDto;
        }


        [HttpPost]

        public async Task<ActionResult> AddPage(Page page)
        {
            await _pageRepo.AddAsync(page);
            return Ok(_mapper.Map<Page, PageToReturnDto>(page));
        }
    }
}
