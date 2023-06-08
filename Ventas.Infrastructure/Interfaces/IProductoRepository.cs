using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        List<ProductoModels> GetProducto();
        List <ProductoModels> GetProducto(int idproducto);
    }
}
