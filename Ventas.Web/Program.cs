using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependecies;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));

//Dependecia//

builder.Services.AddProductoDependecy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
