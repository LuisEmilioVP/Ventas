using Microsoft.EntityFrameworkCore;
using Ventas.Infrastructure.Context;
using Ventas.IOC.Dependencie;
using Ventas.Web.API;
using Ventas.Web.API.ApiServices;
using Ventas.Web.API.ApiServices.Interface;
using Ventas.Web.Http;
using Ventas.Web.Http.HttpService;
using Ventas.Web.Http.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registro de dependencia de la base de datos //
builder.Services.AddDbContext<VentasContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VentasContext")));


//my Dependencies
builder.Services.AddSuplidorDependency();


builder.Services.AddTransient<ISuplidorApiService, SuplidorApiService>();

builder.Services.AddTransient<IApiRepository, ApiRepository>();

builder.Services.AddHttpClient();

builder.Services.AddTransient<ISuplidorHttpService, SuplidorHttpService>();

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