using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Inventory_System.Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public async static Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    FullName = "admin",
                    Email = "admin@inventory.com",
                    UserName = "admin",
                    PhoneNumber = "01111111111",
                    IsActive = true,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
       
        }

    }
}
