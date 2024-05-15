﻿using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Services.Contract
{
    public interface IAuthService
    {
        public Task<string> CreatTokenAsync(AppUser user, UserManager<AppUser> userManager);

    }
}
