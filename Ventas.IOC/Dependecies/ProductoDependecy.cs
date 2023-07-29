using Microsoft.Extensions.DependencyInjection;
using Ventas.Application.Contract;
using Ventas.Application.Service;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Repositories;

namespace Ventas.IOC.Dependecies
{
    public static class ProductoDependecy
    {
        public static void AddProductoDependecy(this IServiceCollection service)
        {
            service.AddScoped<IProductoRepository, ProductoRepository>();
            service.AddTransient<IProductoService, ProductoService>();
        }
    }
}
