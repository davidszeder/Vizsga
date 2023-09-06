using Microsoft.EntityFrameworkCore;
using Vizsgafeladat;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("ReportDbContext");
builder.Services.AddDbContext<ReportDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();