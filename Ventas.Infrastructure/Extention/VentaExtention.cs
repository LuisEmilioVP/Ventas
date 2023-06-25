using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extensions
{
    public static class VentaExtention
    {
        public static VentaModels ConvertVentaEntityToModel(this Venta venta)
        {
            VentaModels ventaModel = new VentaModels()
            {
                NumeroVenta = venta.NumeroVenta,
                IdUsuario = venta.IdUsuario,
                DocumentoCliente = venta.DocumentoCliente,
                NombreCliente = venta.NombreCliente,
                SubTotal = venta.SubTotal,
                ImpuestoTotal = venta.ImpuestoTotal,
                Total = venta.Total,
                FechaRegistro = venta.FechaRegistro
            };

            return ventaModel;
        }
    }
}
