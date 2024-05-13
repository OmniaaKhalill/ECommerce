using E_Commerce.APIs.DTO;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Services.Contract;
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
        private readonly IAuthService _authService;


        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IAuthService authServic)
        {
            _userManager = userManager;
           _signInManager = signInManager;
            _authService=authServic;
        }


        [HttpPost("Login")]

        public  async Task<ActionResult<string>>Login(LoginDto Model)
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

            var token = await _authService.CreatTokenAsync(user, _userManager);

            return Ok(token);
        }


        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register(RegisterDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.DisplayName

            };
            var result = await _userManager.CreateAsync(user, Model.Password);
            if (result.Succeeded is false)
            {
                return BadRequest(440);
            }

            var token = await _authService.CreatTokenAsync(user, _userManager);
            return Ok(token);

           
        }
    }
}
