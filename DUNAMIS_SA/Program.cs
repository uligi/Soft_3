using DUNAMIS_SA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";

    });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});

// Obtener el nombre de la máquina
string machineName = Environment.MachineName;
string connectionString = null;

// Seleccionar la conexión por el nombre de la máquina
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

// Asegurarse de que connectionString no sea nulo
connectionString ??= builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
