using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Data
{
    public static class SeedDataInitializer
    {

        public static async Task SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Check if data already exists
            if (await userManager.FindByNameAsync("Admin") is null)
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    FirsName = "Ali",
                    LastName = "Abdulzahra Jasim"
                };
                PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                passwordHasher.HashPassword(user, "Admin*123");
                var result = await userManager.CreateAsync(user);
            }
            if (roleManager.FindByNameAsync("Admin").Result is null)
            {
                IdentityRole[] roles = {new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }, new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }};
                foreach (var role in roles)
                {
                   await roleManager.CreateAsync(role);
                }
            }

        }

    }
}
