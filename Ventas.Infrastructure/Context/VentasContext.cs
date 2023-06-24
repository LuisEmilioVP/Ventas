using Microsoft.EntityFrameworkCore;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options) 
                                                      : base(options)
        {
        }

        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Categoria>? Categoria { get; set; }
    }
}
