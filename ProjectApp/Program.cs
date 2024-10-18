using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.Core.Interfaces.Interfaces;
using ProjectApp.Persistence;
using Microsoft.AspNetCore.Identity;
using ProjectApp.Areas.Identity.Data;
using ProjectApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency injection of service into controller
builder.Services.AddScoped<IProjectService, ProjectService>();

// projectsdb
builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("ProjectDbConnection")));

// identity
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("IdentityDbConnection")));
builder.Services.AddDefaultIdentity<AppIdentityUser>(
    options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppIdentityDbContext>();

//. dependency injection of persistence into service
builder.Services.AddScoped<IProjectPersistence, MySqlProjectPersistence>();

// auto mapping of data
builder.Services.AddAutoMapper(typeof(Program));
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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();