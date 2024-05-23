using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Domain;
using MigrationProject;

namespace WebApp.SeedData
{
    public class SeedData
    {
        public static async Task SetupAppData( WebApplication app)
        {
            using var serviceScope = ((IApplicationBuilder)app).ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope ();
            using var Context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext> ();

            Context.Database.Migrate();
            if(!Context.TodoCategories.Any())
            {
                string categoriesJson = File.ReadAllText("SeedData/json/todoCategories.json");
                string prioritiesJson = File.ReadAllText("SeedData/json/todoPriorities.json");
                var categories = JsonConvert.DeserializeObject<List<TodoCategory>>(categoriesJson);
                var priorities = JsonConvert.DeserializeObject<List<TodoPriority>>(prioritiesJson);
                await Context.TodoCategories.AddRangeAsync(categories!);
                await Context.TodoPriorities.AddRangeAsync(priorities!);
                await Context.SaveChangesAsync();

                string todosJson = File.ReadAllText("SeedData/json/todos.json");
                var todos = JsonConvert.DeserializeObject<List<Todo>>(todosJson);
                await Context.Todos.AddRangeAsync(todos!);
                await Context.SaveChangesAsync();

            }
        }
    }
}
