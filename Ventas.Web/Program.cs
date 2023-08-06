using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependencies;
using Ventas.Web.APIs;
using Ventas.Web.APIs.ApiServices;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Http;
using Ventas.Web.Http.HttpServices;
using Ventas.Web.Http.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registro dependencia BD
builder.Services.AddDbContext<VentasContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));


//*== MyDepes==*//

builder.Services.AddNegocioDependency();

builder.Services.AddTransient<INegocioApiService, NegocioApiService>();;

builder.Services.AddTransient<IApiRepository, ApiRepository>();

builder.Services.AddHttpClient();

builder.Services.AddTransient<INegocioHttpService, NegocioHttpService>();

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
