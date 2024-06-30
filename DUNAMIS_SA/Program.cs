using DUNAMIS_SA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

// Obtiene el nombre de la máquina
string machineName = Environment.MachineName;
string connectionString = null;

// Selecciona la conexión por el nombre de la máquina
switch (machineName)
{
    case "Ulises":
        connectionString = builder.Configuration.GetConnectionString("Team1Connection");
        break;
    case "Carlos":
        connectionString = builder.Configuration.GetConnectionString("Team2Connection");
        break;
    case "Janiz":
        connectionString = builder.Configuration.GetConnectionString("Team3Connection");
        break;
    case "Mario":
        connectionString = builder.Configuration.GetConnectionString("Team4Connection");
        break;
    case "Ernesto":
        connectionString = builder.Configuration.GetConnectionString("Team5Connection");
        break;
    default:
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        break;
}

// Ensure connectionString is not null
connectionString ??= builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

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

app.UseAuthentication(); // Ensure this line is present
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
