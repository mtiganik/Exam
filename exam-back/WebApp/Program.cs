using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MigrationProject;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using WebApp.Auth;
using WebApp.SeedData;
using WebApp.ServiceImplementation;
using WebApp2.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services
    .AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();

var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
builder.Services
    .AddAuthentication()
    .AddCookie(options => { options.SlidingExpiration = true; })
    .AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = false;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey!)),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.Configure<JwtAuthConfig>(builder.Configuration.GetSection("Jwt"));

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserGetter, UserGetter>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ISuService, SuService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFrontPageService, FrontPageService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Exam", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a jwt token, no Bearer infront! eyJhbGciOiJIUzI1..",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

string testOrigins = "DevelopOrigins";
string[] allowedTestOrigins = {
    "http://localhost:3000",
};

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: testOrigins,
        policy =>
        {
            policy.WithOrigins(allowedTestOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

builder.Services.AddControllersWithViews();


var app = builder.Build();

await SeedData.SetupAppData(app);

app.UseCors(testOrigins);


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Kahkukas API v1");
    options.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
