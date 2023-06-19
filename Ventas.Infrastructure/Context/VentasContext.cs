using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentasContext : DbContext
    {
        internal readonly IEnumerable<object> Venta1;

        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options) 
            : base(options)
        {
        }

        public DbSet<Venta> Ventas { get; set; }
    }
}
