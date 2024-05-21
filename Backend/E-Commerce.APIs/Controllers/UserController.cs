using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Repositories.Contract;
using E_Commerce.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public UserController(
            IUnitOfWork unit,
            IMapper mapper
            )
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
           
            var user = await unit.UserRepo.GetAsync(id);

            if (user == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(mapper.Map<AppUser, UserDto>(user));
        }



        [HttpPatch("{id}")]
        public async Task<ActionResult<UserToReturnDTO>> UpdateUser(string id, UserToReturnDTO updatedUserDto)
        {
            if (id is null)
                return BadRequest(new { Message = "Invalid user ID", StatusCode = "400" });

            // Retrieve the existing user entity
            var existingUser = await unit.UserRepo.GetAsync(id);
            if (existingUser == null)
                return NotFound(new { Message = "User not found", StatusCode = "404" });

            existingUser.DisplayName = updatedUserDto.DisplayName;
            existingUser.UserName = updatedUserDto.UserName;
            existingUser.Email = updatedUserDto.Email;
            existingUser.Address = updatedUserDto.Address;
            existingUser.PhoneNumber = updatedUserDto.PhoneNumber;
            

            // Save the changes
            await unit.UserRepo.SaveChanges();

            // Map the updated user entity to DTO
            var updatedDto = mapper.Map<AppUser, UserToReturnDTO>(existingUser);
            return updatedDto;
        }



    }
}
