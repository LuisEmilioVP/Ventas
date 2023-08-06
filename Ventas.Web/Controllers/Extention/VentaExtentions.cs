using Ventas.Application.Dto.Venta;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Venta;
using Ventas.Web.Models.Venta.Request;

namespace Ventas.Web.Controllers.Extentions
{
    public static class VentaExtentions
    {
        //* Para Api y sin Api
        public static BaseVentaModel ConverterModelTousuarioResponse(this VentaModels venta)
        {
            return new BaseVentaModel
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
        }
        //* Sin Api
        public static VentaUpdateRequest ConvertVentaToUpdateRequest (this VentaModels venta)
        {
            return new VentaUpdateRequest()
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
        }
        //* Con Api
        public static VentaUpdateRequest ConvertVentaToUpdateRequest(this BaseVentaModel venta)
        {
            return new VentaUpdateRequest()
            {
                IdUsuario = venta.IdUsuario,
                IdVenta = venta.IdVenta,
                NumeroVenta = venta.NumeroVenta,
                DocumentoCliente = venta.DocumentoCliente,
                NombreCliente = venta.NombreCliente,
                SubTotal = venta.SubTotal,
                ImpuestoTotal = venta.ImpuestoTotal,
                Total = venta.Total,
                FechaRegistro = venta.FechaRegistro
            };
        }
        //* Para Api y sin Api
        public static VentaAddDto ConvertAddRequestToAddDto(this VentaAddRequest ventaAdd)
        {
            return new VentaAddDto()
            {
              
                NumeroVenta = ventaAdd.NumeroVenta,
                DocumentoCliente = ventaAdd.DocumentoCliente,
                NombreCliente = ventaAdd.NombreCliente,
                SubTotal = ventaAdd.SubTotal,
                ImpuestoTotal = ventaAdd.ImpuestoTotal,
                Total = ventaAdd.Total,
                FechaRegistro = ventaAdd.FechaRegistro
                ChangeUser = ventaAdd.ChangeUser,
                ChangeDate = ventaAdd.ChangeDate
            };
        }
        //* Para Api y sin Api
        public static VentaUpdateDto ConvertUpdateRequestToUpdateDto (this VentaUpdateRequest ventaUpdate)
        {
            return new VentaUpdateDto()
            {
                
                IdVenta = ventaUpdate.IdVenta,
                NumeroVenta = ventaUpdate.NumeroVenta,
                DocumentoCliente = ventaUpdate.DocumentoCliente,
                NombreCliente = ventaUpdate.NombreCliente,
                SubTotal = ventaUpdate.SubTotal,
                ImpuestoTotal = ventaUpdate.ImpuestoTotal,
                Total = ventaUpdate.Total,
                FechaRegistro = ventaUpdate.FechaRegistro,
                ChangeUser = ventaUpdate.ChangeUser,
                ChangeDate = ventaUpdate.ChangeDate
            };
        }
        //* Para Api y sin Api
        public static VentaRemoveDto ConvertRemoveDtoToRemoveRequest (this VentaRemoveRequest ventaRemove)
        {
            return new VentaRemoveDto()
            {
                IdVenta = ventaRemove.IdVenta,
                Deleted = ventaRemove.Deleted,
                ChangeUser = ventaRemove.ChangeUser,
                ChangeDate = ventaRemove.ChangeDate
            };
        }
    }
}
