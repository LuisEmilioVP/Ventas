
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class VentaExtention
    {
        public static VentaModels ConvertVentaEntityToModel(this Venta Venta)
        {
            VentaModels VentaModels = new VentaModels()
             {
                 NumeroVenta = Venta.NumeroVenta,
                 IdUsuario = Venta.IdUsuario,
                 DocumentoCliente = Venta.DocumentoCliente,
                 NombreCliente = Venta.NombreCliente,
                 SubTotal = Venta.SubTotal,
                 ImpuestoTotal = Venta.ImpuestoTotal,
                 Total = Venta.Total,
                 FechaRegistro = Venta.FechaRegistro

             };
            return VentaModels;
        }
    }
}
