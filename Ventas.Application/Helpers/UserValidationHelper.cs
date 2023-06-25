using System.Text.RegularExpressions;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Venta;

namespace Ventas.Application.Helpers
{
    public static class VentaValidationHelper
    {
        public static ServiceResult ValidateVentaData(VentaDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.NumeroVenta))
            {
                result.Message = "El número de venta es requerido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.DocumentoCliente))
            {
                result.Message = "El documento del cliente es requerido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.NombreCliente))
            {
                result.Message = "El nombre del cliente es requerido";
                result.Success = false;
                return result;
            }

            if (model.SubTotal <= 0)
            {
                result.Message = "El subtotal debe ser mayor a cero";
                result.Success = false;
                return result;
            }

            if (model.ImpuestoTotal <= 0)
            {
                result.Message = "El impuesto total debe ser mayor a cero";
                result.Success = false;
                return result;
            }

            if (model.Total <= 0)
            {
                result.Message = "El total debe ser mayor a cero";
                result.Success = false;
                return result;
            }

            // Agrega más validaciones según tus requisitos

            return result;
        }
    }
}
