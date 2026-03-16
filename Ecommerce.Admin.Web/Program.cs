using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.CrossCutting.Middleware;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ProductService>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();