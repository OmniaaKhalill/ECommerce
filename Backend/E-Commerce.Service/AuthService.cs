using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http.Logging;
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
                new Claim ("Name",user.DisplayName),
                new Claim ("Email",user.Email),
                new Claim ("UserId",user.Id),

            };

            var userRols = await userManager.GetRolesAsync(user);

            if (userRols.Count > 1)
            { 
                authClaims.Add(new Claim("IsSeller", "true"));
            }

            else
            {
                authClaims.Add(new Claim("IsSeller", "false"));
            }

            authClaims.Add(new Claim("Role", "user"));


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
