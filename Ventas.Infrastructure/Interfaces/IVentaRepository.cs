using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public  interface IVentaRepository : IBaseRepository<Venta>
    {
        List<VentaModels> GetAllVenta();
        VentaModels GetVentaById(int id);

    }
}
