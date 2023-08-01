
using Ventas.Application.Dto.Venta;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extentions
{
    public static class VentaExtention
    {
        public static Venta ConvertDtoAddToEntity(this VentaAddDto VentaAddDto)
        {
            return new Venta()
            {
                NumeroVenta = VentaAddDto.NumeroVenta,
                IdUsuario = VentaAddDto.IdUsuario,
                DocumentoCliente = VentaAddDto.DocumentoCliente,
                NombreCliente = VentaAddDto.NombreCliente,
                SubTotal = VentaAddDto.SubTotal,
                ImpuestoTotal = VentaAddDto.ImpuestoTotal,
                Total = VentaAddDto.Total,

            };
        }

        public static Venta ConvertDtoUpdateToEntity(this VentaUpdateDto VentaUpdateDto)
        {
            return new Venta()
            {
            
                NumeroVenta = VentaUpdateDto.NumeroVenta,
                IdUsuario = VentaUpdateDto.IdUsuario,
                DocumentoCliente = VentaUpdateDto.DocumentoCliente,
                NombreCliente = VentaUpdateDto.NombreCliente,
                SubTotal = VentaUpdateDto.SubTotal,
                ImpuestoTotal = VentaUpdateDto.ImpuestoTotal,
                Total = VentaUpdateDto.Total,


            };
        }



    }
}
