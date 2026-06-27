using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory_System.Infrastructure.Identity
{
    public static class RoleSeed
    {
        public async static Task SeedRoleAsync(RoleManager<IdentityRole> roleManager)
        {      
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

        }
    }
}
