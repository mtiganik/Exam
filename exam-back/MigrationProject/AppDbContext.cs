using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MigrationProject
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid,
    IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
    {
        public DbSet<Grade> Grades { get; set; } = default!;
        public DbSet<Homework> Homeworks{ get; set; } = default!;
        public DbSet<HwForStudent> HwForStudents { get; set; } = default!;
        public DbSet<Semester> Semesters{ get; set; } = default!;
        public DbSet<Subject> Subjects{ get; set; } = default!;
        public DbSet<UserInSubject> UsersInSubject { get; set; } = default!;
        public DbSet<UserRoleInSubject> UsersRoleInSubject { get; set; } = default!;
        public DbSet<TodoPriority> TodoPriorities { get; set; } = default!;
        public DbSet<TodoCategory> TodoCategories { get; set; } = default!;
        public DbSet<Todo> Todos { get; set; } = default!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=exam;Username=postgres;Password=qwerty");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
