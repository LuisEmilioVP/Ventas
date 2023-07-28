using Microsoft.EntityFrameworkCore;

using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

//*== Add services to the container. ==*//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*== Registro dependencia BD ==*//
builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));

//*== My Dependencies ==*//
builder.Services.AddCategoriaDependency();
builder.Services.AddUsuarioDependency();

var app = builder.Build();

//*== Configure the HTTP request pipeline. ==*//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();