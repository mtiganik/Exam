using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace DbConnection
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; } = default!;
        public DbSet<TodoCategory> TodoCategories { get; set; } = default!; 
        public DbSet<TodoPriority> TodoPriorities { get; set;} = default!; 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
    }
}
