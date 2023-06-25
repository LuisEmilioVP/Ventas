using Ventas.Application.Dtos.Venta;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extensions
{
    public static class VentaExtension
    {
        public static Venta ConvertDtoToAddEntity(this VentaAddDto ventaAddDto)
        {
            return new Venta()
            {
                NumeroVenta = ventaAddDto.NumeroVenta,
                IdUsuario = ventaAddDto.IdUsuario,
                DocumentoCliente = ventaAddDto.DocumentoCliente,
                NombreCliente = ventaAddDto.NombreCliente,
                SubTotal = ventaAddDto.SubTotal,
                ImpuestoTotal = ventaAddDto.ImpuestoTotal,
                Total = ventaAddDto.Total,
                
              
            };
        }

        public static Venta ConvertDtoToUpdateEntity(this VentaUpdateDto ventaUpdateDto)
        {
            return new Venta()
            {
                IdVenta = ventaUpdateDto.IdUVenta,
                NumeroVenta = ventaUpdateDto.NumeroVenta,
                IdUsuario = ventaUpdateDto.IdUsuario,
                DocumentoCliente = ventaUpdateDto.DocumentoCliente,
                NombreCliente = ventaUpdateDto.NombreCliente,
                SubTotal = ventaUpdateDto.SubTotal,
                ImpuestoTotal = ventaUpdateDto.ImpuestoTotal,
                Total = ventaUpdateDto.Total,
              
            
            };
        }
    }
}
