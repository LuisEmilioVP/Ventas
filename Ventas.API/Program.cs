using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de dependencia base de datos
builder.Services.AddDbContext<VentasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));


// Repositorio
builder.Services.AddTransient<ISuplidorRepository, SuplidorRepository>();



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
