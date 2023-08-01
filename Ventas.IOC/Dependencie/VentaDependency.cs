using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependencie
{
    public static class VentaDependency
    {
        public static void AddSuplidorDependency(this IServiceCollection services)
        {
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddTransient<IVentaService, VentaService>();
        }
    }
}
