using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependencies
{
    public static class NegocioDependency
    {
        public static void AddNegocioDependency(this IServiceCollection services)
        {
            services.AddScoped<INegocioRepository, NegocioRepository>();
            services.AddTransient<INegocioService, NegocioService>();
        }
    }
}
