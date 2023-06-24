using Microsoft.EntityFrameworkCore;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//*== Add services to the container. ==*//

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*== Registro dependencia BD ==*//
builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));

//*== Repositorios ==*//
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddTransient<ICategoriaRepository, CategoriasRepository>();

//*== Referencias de app servoces ==*//
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

builder.Services.AddTransient<ICategoriaService, CategoriaService>();


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
