using DUNAMIS_SA.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Obtiene el nombre de la maquina
string machineName = Environment.MachineName;
string connectionString = null;

// Selecciona la conexion por el nombre
switch (machineName)
{
    case "Team1MachineName":
        connectionString = builder.Configuration.GetConnectionString("Team1Connection");
        break;
    case "Team2MachineName":
        connectionString = builder.Configuration.GetConnectionString("Team2Connection");
        break;
    case "Team3MachineName":
        connectionString = builder.Configuration.GetConnectionString("Team3Connection");
        break;
    case "Team4MachineName":
        connectionString = builder.Configuration.GetConnectionString("Team3Connection");
        break;
    case "Team5MachineName":
        connectionString = builder.Configuration.GetConnectionString("Team3Connection");
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
