using BCASRequireMates.Constants;
using BCASRequireMates.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace BCASRequireMates.Data
{
    public class DbSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {

            //seedRoles
            var userManager = serviceProvider.GetService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            //await roleManager.CreateAsync(new IdentityRole("Admin")); //pwede din tong approach
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Create the Admin user
            var adminUser = new AppUser
            {
                UserName = "admin@domain.com",
                Email = "admin@domain.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(adminUser, "AdminPassword123!");
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());

            }
        }
    }
}
