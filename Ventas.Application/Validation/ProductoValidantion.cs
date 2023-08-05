using Ventas.Application.Core;
using Ventas.Application.Dtos.Producto;

namespace Ventas.Application.Validation
{
    public static class ProductoValidantion
    {
        public static ServiceResult ValidantionIdProducto(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id <= 0)
            {
                result.Message = $"Id de producto inválido {id}";
                result.Success = false;
                return result;
            }

            if (id == null)
            {
                result.Message = $"El id no puede ser nulo";
                result.Success = false;
                return result;
            }

            return result;
        }

        public static ServiceResult ValidantionAddProducto(ProductoAddDto addProducto)
        {
            ServiceResult result = new ServiceResult();

            if (addProducto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quién añadira un producto";
                result.Success = false;
                return result;
            }

            if (addProducto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(addProducto.CodigoBarra))
            {
                result.Message = "El codigo de barra es obligatorio";
                result.Success = false;
                return result;
            }

            if (addProducto.CodigoBarra.Length > 50)
            {
                result.Message = "El Codigo de barra tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(addProducto.Marca))
            {
                result.Message = "El marca es obligatorio";
                result.Success = false;
                return result;
            }

            if (addProducto.Marca.Length > 50)
            {
                result.Message = "La marca tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (addProducto.Precio <= 0)
            {
                result.Message = "El precio no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (addProducto.Stock <= 0)
            {
                result.Message = "El stock no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (addProducto.UrlImagen.Length > 500)
            {
                result.Message = "La URL es demasiado larga";
                result.Success = false;
                return result;
            }

            if (addProducto.NombreImagen.Length > 100)
            {
                result.Message = "El nombre de la foto es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidantionUpdateProducto(ProductoUpdateDto UpdateProducto)
        {

            ServiceResult result = new ServiceResult();

            if (UpdateProducto.IdProducto != UpdateProducto.IdProducto)
            {
                result.Message = "ID no detectado. Indique el producto a actualizar";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.IdProducto <= 0)
            {
                result.Message = "Id del producto inválido";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quien actualizara";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(UpdateProducto.CodigoBarra))
            {
                result.Message = "El codigo de barra es obligatorio";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.CodigoBarra.Length > 50)
            {
                result.Message = "El Codigo de barra tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (string.IsNullOrEmpty(UpdateProducto.Marca))
            {
                result.Message = "El marca es obligatorio";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.Marca.Length > 50)
            {
                result.Message = "La marca tiene la logitud invalida.";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.Precio <= 0)
            {
                result.Message = "El precio no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.Stock <= 0)
            {
                result.Message = "El stock no puede ser cero.";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.UrlImagen.Length > 500)
            {
                result.Message = "La URL es demasiado larga";
                result.Success = false;
                return result;
            }

            if (UpdateProducto.NombreImagen.Length > 100)
            {
                result.Message = "El nombre de la foto es demasiado largo";
                result.Success = false;
                return result;
            }

            return result;

        }

        public static ServiceResult ValidationRemoveProducto(ProductoRemoveDto RemoveProducto)
        {
            ServiceResult result = new ServiceResult();

            if (RemoveProducto.IdProducto != RemoveProducto.IdProducto)
            {
                result.Message = "ID no detectado. Indique el producto a eliminar";
                result.Success = false;
                return result;
            }

            if (RemoveProducto.IdProducto <= 0)
            {
                result.Message = "Id del producto inválido";
                result.Success = false;
                return result;
            }

            if (RemoveProducto.ChangeUser == null)
            {
                result.Message = "ID no detectado. Indique quien esta eliminando";
                result.Success = false;
                return result;
            }

            if (RemoveProducto.ChangeUser <= 0)
            {
                result.Message = "Id de usuario inválido";
                result.Success = false;
                return result;
            }

            return result;
        }
    }

    
}
