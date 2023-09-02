using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vizsgafeladat;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReportDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();
app.UseRouting();
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();