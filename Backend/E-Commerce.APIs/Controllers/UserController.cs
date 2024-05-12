using AutoMapper;
using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {

        private readonly IGenericRepositoryUser<AppUser> _userRepo;
        private readonly IMapper _mapper;

        public UserController(IGenericRepositoryUser<AppUser> userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserToReturnDTO>> UpdateUser(int id, AppUser entity)
        {
            if (id <= 0)
                return BadRequest(new { Message = "Invalid user ID", StatusCode = "400" });

            var updatedUser = await _userRepo.UpdateAsync(id, entity);
            if (updatedUser == null)
                return NotFound(new { Message = "User not found", StatusCode = "404" });

            var updatedDto = _mapper.Map<AppUser, UserToReturnDTO>(updatedUser);
            return updatedDto;
        }


    }
}
