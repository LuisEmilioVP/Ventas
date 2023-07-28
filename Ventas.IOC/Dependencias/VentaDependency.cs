
using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependencies
{
    public static class UsuarioDependency
    {
        public static void AddUsuarioDependency(this IServiceCollection services)
        {
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddTransient<IVentaService, VentaService>();
        }
    }
}