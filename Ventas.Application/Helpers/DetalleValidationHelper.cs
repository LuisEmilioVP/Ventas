
using Ventas.Application.Core;
using Ventas.Application.Dtos.DetalleVenta;

namespace Ventas.Application.Helpers
{
    public static class DetalleValidationHelper
    {
        public static ServiceResult ValidateVentaData(DetalleVentaDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.NumeroVenta))
            {
                result.Message = "El número de venta es requerido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.marcaProducto))
            {
                result.Message = "La Marca del producto es requerido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(model.descripcionProducto))
            {
                result.Message = "La descripcion Del Producto es requerido";
                result.Success = false;
                return result;
            }

            if (model.cantidad <= 0)
            {
                result.Message = "La cantida debe ser mayor a cero";
                result.Success = false;
                return result;
            }

            if (model.precio <= 0)
            {
                result.Message = "El precio debe ser mayor a cero";
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
