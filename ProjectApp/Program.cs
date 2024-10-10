using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces.Interfaces;
using ProjectApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency injection of service into controller
builder.Services.AddScoped<IProjectService, MockProjectService>();

// auto mapping of data
builder.Services.AddAutoMapper(typeof(Program));

//projectsdb
builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("ProjectDbConnection")));
   
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
  