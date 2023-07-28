
using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependencies
{
    public static class DetalleVentaDependency
    {
        public static void AddCategoriaDependency(this IServiceCollection services)
        {
            services.AddScoped<IDetalleVenta, DetalleVentaRepository>();
            services.AddTransient<IDetalleVentaService, DetalleVentaService>();
        }
    }
}