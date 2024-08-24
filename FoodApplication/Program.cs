using FoodApplication.ContextDBConfing;
using FoodApplication.Models;
using FoodApplication.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
var dbconnectoin = builder.Configuration.GetConnectionString("dbConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();
if (string.IsNullOrEmpty(dbconnectoin))
{
    throw new InvalidOperationException("Database connection string is null or empty");
}
else
{
    builder.Services.AddDbContext<FoodApplicationDBContext>(options =>
options.UseSqlServer(dbconnectoin));
}


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<FoodApplicationDBContext>();

builder.Services.AddTransient<IData, Data>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
