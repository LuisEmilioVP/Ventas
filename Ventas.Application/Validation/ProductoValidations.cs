

using Ventas.Application.Core;
using Ventas.Application.Dtos.Producto;

namespace Ventas.Application.Help
{
    public static class ProductoValidations
    {
        public static ServiceResult ValidateProducto(ProductoDtos model)
        {
            ServiceResult result = new ServiceResult();

            if (model.CodigoBarra.Length > 50)
            {
                result.Message = "El Codigo de barra tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.Marca.Length > 50)
            {
                result.Message = "La marca tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.Descripcion.Length > 100)
            {
                result.Message = "La descripcion tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.UrlImagen.Length > 500)
            {

                result.Message = "El UrlImagen tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.NombreImagen.Length > 100)
            {
                result.Message = "El nombre de la imagen tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (model.Precio <= 0)
            {
                result.Message = "El precio no puede ser cero.";
                result.Success = false;
                return result;
            }

            return result;
        }
    }
}
