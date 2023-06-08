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

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
