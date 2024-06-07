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
        public DbSet<AppRefreshToken> RefreshTokens { get; set; } = default!;
        public DbSet<Company> Companies { get; set; } = default!;
        public DbSet<Item> Items { get; set; } = default!;

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
