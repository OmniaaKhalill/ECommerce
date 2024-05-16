using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{

    public class ReviewsController : BaseApiController
    {

        private readonly IUnitOfWork _unit;


        private readonly IMapper _mapper;

        public ReviewsController( IUnitOfWork unit, IMapper mapper ) 
        {
            _unit = unit;
            _mapper = mapper;
          
          
        }
        [HttpPost("{productId}")]
        public async Task<ActionResult> AddReview(ReviewsDto review, int productId , string userId)
        {

           
            var product = await _unit.ProductRepo.GetAsync(productId);

            
          
            var user = await _unit.UserRepo.GetAsync(userId);
         
            if (product == null)
            {
                return NotFound(new { Message = "Product not found", StatusCode = 404 });
            }
            else
            {
              
                review.ProductId = productId;
                review.UserId = userId;
                review.Product = product;
                review.User = user;

              var mappedReview=  _mapper.Map<ReviewsDto, Review>(review);

              var addedPage = await _unit.ReviewRepo.AddAsync(mappedReview, productId,userId);
                var reviewDto = _mapper.Map<Review, ReviewsToReturnDto>(addedPage);

                return Ok(reviewDto);
            }
        }


    }
}
