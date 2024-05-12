using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E_Commerce.Repository.Data
{
    public static class AppIdentityDbContextDataSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (userManager.Users.Count()==0) {
                var user = new AppUser()
                {
                    DisplayName="yasmeen",
                    Email="yasmeen@gmail.com",
                    UserName="yasmeen.hassan",
                    PhoneNumber="01204668540",
                   
                };
                await userManager.CreateAsync(user,"Pa$$w0rd");
            }
        }
    }
}
