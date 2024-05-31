using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Newtonsoft.Json;

namespace WebApp2.SeedData
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
            {
                using var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                using var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
                await roleManager.CreateAsync(new AppRole { Name = "Teacher" });
                await roleManager.CreateAsync(new AppRole { Name = "Student" });

                var admin = new AppUser()
                {
                    Email = "mtiganik@gmail.com",
                    UserName = "mtiganik@gmail.com"
                };
                admin.Id = new Guid("ddcefa48-5a53-48fb-9d12-85636ff2c55e");
                await userManager.CreateAsync(admin, "qwerty");
                await userManager.AddToRoleAsync(admin, "Admin");

                string teachersJson = File.ReadAllText("SeedData/json/teachers.json");
                string studentsJson = File.ReadAllText("SeedData/json/students.json");

                var teachers = JsonConvert.DeserializeObject<List<AppUser>>(teachersJson);
                var students = JsonConvert.DeserializeObject<List<AppUser>>(studentsJson);
                foreach (var user in teachers!)
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    await userManager.CreateAsync(user, user.Email!);
                    await userManager.AddToRoleAsync(user, "Teacher");
                }
                foreach(var user in students!)
                {
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    await userManager.CreateAsync(user, user.Email!);
                    await userManager.AddToRoleAsync(user, "Student");
                }
                string semesterNameJson = File.ReadAllText("SeedData/json/semester-name.json");
                string userRoleInSubjectJson = File.ReadAllText("SeedData/json/user-role-in-subject.json");
                string gradeJson = File.ReadAllText("SeedData/json/grades.json");
                var semesterNames = JsonConvert.DeserializeObject<List<Semester>>(semesterNameJson);
                var rolesInSubjects = JsonConvert.DeserializeObject<List<UserRoleInSubject>>(userRoleInSubjectJson);
                var grades          = JsonConvert.DeserializeObject<List<Grade>>(gradeJson);
                await context.Semesters.AddRangeAsync(semesterNames!);
                await context.UsersRoleInSubject.AddRangeAsync(rolesInSubjects!);
                await context.Grades.AddRangeAsync(grades!);
                await context.SaveChangesAsync();

                string subjectJson = File.ReadAllText("SeedData/json/subjects.json");
                var subjects = JsonConvert.DeserializeObject<List<Subject>>(subjectJson);
                await context.Subjects.AddRangeAsync(subjects!);
                await context.SaveChangesAsync();

                string userInSubjectJson = File.ReadAllText("SeedData/json/user-in-subject.json");
                string hwJson = File.ReadAllText("SeedData/json/homeworks.json");
                var userInSubject = JsonConvert.DeserializeObject<List<UserInSubject>>(userInSubjectJson);
                var hws = JsonConvert.DeserializeObject<List<Homework>>(hwJson);
                await context.UsersInSubject.AddRangeAsync(userInSubject!);
                await context.Homeworks.AddRangeAsync(hws!);
                await context.SaveChangesAsync();

                string hwfsJson = File.ReadAllText("SeedData/json/hw-for-students.json");
                var hwfs = JsonConvert.DeserializeObject<List<HwForStudent>>(hwfsJson);
                await context.HwForStudents.AddRangeAsync(hwfs!);
                await context.SaveChangesAsync();

            }
        }
    }
}
