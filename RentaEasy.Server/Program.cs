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

// Register repositories and services
builder.Services.AddScoped<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddScoped<PropertyService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors("AllowAll");

// Enable Swagger for API documentation
//app.UseSwagger();
//app.UseSwaggerUI();

app.MapControllers();
app.Run();
