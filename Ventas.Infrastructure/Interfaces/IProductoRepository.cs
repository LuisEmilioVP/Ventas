
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<ProductoModels> GetAllProducto();
        ProductoModels GetProductoById(int idproducto);
    }
}
