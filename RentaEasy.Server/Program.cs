using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentaEasy.Application.Services;
using RentaEasy.Core.Interfaces;
using RentaEasy.Infrastructure.Data;
using RentaEasy.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure EF Core with In-Memory Database
builder.Services.AddDbContext<RentaEasyDbContext>(options =>
    options.UseInMemoryDatabase("RentaEasyDb"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RentaEasyDbContext>()
    .AddDefaultTokenProviders(); 

// Register repositories and services
builder.Services.AddScoped<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddScoped<PropertyService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
