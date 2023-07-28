using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;


namespace Ventas.Infrastructure.Interfaces
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        dynamic GetAllVenta();
        List<Venta> GetAllVentas();

        List<Venta> GetVentaById(int idVenta);
        void Update(object venta);
    }
}
