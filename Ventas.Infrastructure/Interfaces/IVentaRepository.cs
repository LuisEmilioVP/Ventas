using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        List<Venta> GetAllVentas();

        List<Venta> GetVenta(int idVenta);
    }
}
