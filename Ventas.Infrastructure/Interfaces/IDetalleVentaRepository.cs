using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using DetalleVentas.Infrastructure.Models.cs;
using DetalleVentas.Domain.Entities;

namespace DetalleVentas.Infrastructure.Interfaces
{
    public interface IDetalleVentaRepository : IBaseRepository<DetalleVenta>
    {
        void Add(DetalleVenta entity);
        dynamic GetAllDetalle();
        List<DetalleVentaModels> GetAllDetalleVentas();

        List<DetalleVentaModels> GetDetalleVentaById(int idDetalleVenta);

    }
}
