using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BursaryApplication.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices.GetRequiredService<AppIdentityDbContext>();
            context.Database.Migrate();
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                await userManager.CreateAsync(new IdentityUser("Admin"), adminPassword);
                await userManager.CreateAsync(new IdentityUser("Admin2"), "SomePassw0rd@");
                await userManager.CreateAsync(new IdentityUser("Admin3"), "NewPassw0rd@");
                await userManager.CreateAsync(new IdentityUser("Admin4"), "NewAdmin123@");
                await userManager.CreateAsync(new IdentityUser("Admin5"), "Admin123@");
            }
        }

    }
}
