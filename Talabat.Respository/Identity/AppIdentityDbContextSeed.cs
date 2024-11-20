using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Respository.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task IdentitySeedAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    Email = "ahmedaminc41@gmail.com",
                    DisplayName = "Ahmed Amin",
                    UserName = "ahmed.amin",
                    PhoneNumber = "0112233344455",

                };

                await _userManager.CreateAsync(user, "Pa$$W0rd");
            }
        }
    }
}
