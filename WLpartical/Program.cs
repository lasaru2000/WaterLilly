using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using WLpartical.Models;
using WLpartical.Repositories;
using WLpartical.Repository;
using WLpartical.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WaterlilyContext>(Options =>
     Options.UseSqlServer(builder.Configuration.GetConnectionString("Dbconnection")));

// Register your repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();



// Register your services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<HolidayService>();

//Register caching 
builder.Services.AddMemoryCache();


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
