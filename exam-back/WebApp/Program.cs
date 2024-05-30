
using Microsoft.EntityFrameworkCore;
using MigrationProject;
using Services.Implementation;
using Services.Interfaces;
using WebApp.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container11.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
Console.WriteLine("Conn string:");
Console.WriteLine(connectionString.Split(new string[] { "Password" }, StringSplitOptions.None)[0]);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<ITodoPriorityService, TodoPriorityService>();
builder.Services.AddScoped<ITodoCategoryService, TodoCategoryService>();
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await SeedData.SetupAppData(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
