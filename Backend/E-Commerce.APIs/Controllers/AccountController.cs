using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
