using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependecies;
using Ventas.Web.APIs;
using Ventas.Web.APIs.ApiServices;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Http;
using Ventas.Web.Http.HttpServices;
using Ventas.Web.Http.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));

//Dependecia//

builder.Services.AddProductoDependecy();

builder.Services.AddTransient<IApiRepository, ApiRepository>();

builder.Services.AddTransient<IProductoApiService, ProductoApiService>();

builder.Services.AddHttpClient();

builder.Services.AddTransient<IProductoHttpService, ProductoHttpService>();

builder.Services.AddTransient<IHttpRepository, HttpRepository>();


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
