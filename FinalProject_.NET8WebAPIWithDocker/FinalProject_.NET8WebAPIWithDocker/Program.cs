using FinalProject_.NET8WebAPIWithDocker.Data;
using Microsoft.EntityFrameworkCore;
using FinalProject_.NET8WebAPIWithDocker.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//add swagger

builder.Services.AddSwaggerGen();

//add db context

var configuration = builder.Configuration;


builder.Services.AddTransient<IRepository, Repository>();

builder.Services.AddDbContext<InsuranceContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));




var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
