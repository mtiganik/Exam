using Domain;
using Microsoft.EntityFrameworkCore;

namespace MigrationProject
{
    public class AppDbContext : DbContext
    {
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
