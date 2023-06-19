using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IVentaRepository : IBaseRepository<Venta>
    {
        void Add(Venta entity);
        object GetAllEntities();
        List<Venta> GetAllVentas();

        List<Venta> GetVentaById(int idVenta);
        void Update(Venta entity);
    }
}
