using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace E_Commerce.Service
{
    public class AuthService : IAuthService
    { private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
    

        }
        public async Task<string> CreatTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
        
            var authClaims = new List<Claim>()
            {
                new Claim (ClaimTypes.GivenName,user.DisplayName),
                new Claim (ClaimTypes.Email,user.Email)

            };

            var userRols = await userManager.GetRolesAsync(user);

            foreach (var role in userRols)
            {
                authClaims.Add(new Claim (ClaimTypes.Role, role));
            }
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                audience: _configuration["JWT:ValidAudiance"],
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddDays(1),
                claims:authClaims,
                signingCredentials: new SigningCredentials(authKey,SecurityAlgorithms.HmacSha256Signature)
                );




            return new JwtSecurityTokenHandler().WriteToken(token);
        }

  
    }
}
