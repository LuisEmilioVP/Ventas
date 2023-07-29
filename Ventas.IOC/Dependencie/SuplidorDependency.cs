using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependencie
{
    public static class SuplidorDependency
    {
        public static void AddSuplidorDependency(this IServiceCollection services)
        {
            services.AddScoped<ISuplidorRepository, SuplidorRepository>();
            services.AddTransient<ISuplidorService, SuplidorService>();
        }
    }
}
