using Microsoft.AspNetCore.Identity;
using FirmaTakip.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip
{
    public class IdentityInitializer
    {
        public static void OlusturAdmin(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Kadir",
                SurName = "Kurhan",
                UserName = "Kadir"
            };
            if (userManager.FindByNameAsync("Kadir").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser, "1").Result;
            }

            if (roleManager.FindByNameAsync("Admin").Result == null)
            {

                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                var idendityResult = roleManager.CreateAsync(role).Result;
                var result = userManager.AddToRoleAsync(appUser, role.Name).Result;

            }
        }
    }
}
