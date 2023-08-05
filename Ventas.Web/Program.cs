using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependecies;
using Ventas.Web.APIs;
using Ventas.Web.APIs.ApiServices;
using Ventas.Web.APIs.ApiServices.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));

//Dependecia//

builder.Services.AddProductoDependecy();

builder.Services.AddTransient<IApiRepository, ApiRepository>();

builder.Services.AddTransient<IProductoApiService, ProductoApiService>();


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
