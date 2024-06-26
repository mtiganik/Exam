﻿using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
using System.Diagnostics;

namespace WebApp.SeedData
{
    public class SeedData
    {

        public static async Task SetupAppData(WebApplication app)
        {
            using var serviceScope = ((IApplicationBuilder)app).ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.Migrate();

            if (!context.Users.Any())
            //if (true)
            {

                using var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                using var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                await roleManager.CreateAsync(new AppRole { Name = "admin" });
                await roleManager.CreateAsync(new AppRole { Name = "su" });
                await roleManager.CreateAsync(new AppRole { Name = "user" });

                var admin = new AppUser()
                {
                    Email = "mtiganik@gmail.com",
                    UserName = "mihkel",
                };
                Guid CompanyId = new Guid("d9d87ed8-a54f-4c70-8cc4-ae81fe68a7df");
                Company AdminCompany = new Company()
                {
                    CompanyName = "Admin company Do not delete",
                    ActivityMinutes = 10,
                    Id = CompanyId,
                    SuEmail = "admin@admin.ee",
                    SuName = "admin",
                    SuPw = "qwerty",
                    IsPublic = false,
                    Sort1 = 1,
                    Sort2 = 1,
                    Tag = "admin"
                };
                admin.Id = new Guid("ddcefa48-5a53-48fb-9d12-85636ff2c55e");
                admin.CompanyId = CompanyId;
                await context.Companies.AddAsync(AdminCompany);
                await userManager.CreateAsync(admin, "qwerty");
                await userManager.AddToRoleAsync(admin, "Admin");
                await context.SaveChangesAsync();
            }


        }
    }
}
