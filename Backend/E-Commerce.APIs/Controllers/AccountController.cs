using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.Api.Dto;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
           _signInManager = signInManager;
        }


        [HttpPost("Login")]

        public  async Task<ActionResult<UserDto>>Login(LoginDto Model)
        {
            var user=await _userManager.FindByEmailAsync(Model.Email);
            if (user is null)
            {
                return Unauthorized();
            }
            var result=await _signInManager.CheckPasswordSignInAsync(user,Model.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return Ok(new UserDto() { 
            DisplayName = user.DisplayName,
            Email = Model.Email,
            Token="first token"
            });
        }


        [HttpPost("Register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.Email.Split("@")[0],
                PhoneNumber = Model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, Model.Password);
            if (result.Succeeded is false)
            {
                return BadRequest(400);
            }
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "this will be token"

            });
        }
    }
}
