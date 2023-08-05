using Ventas.Application.Dtos.Producto;
using Ventas.Infrastructure.Models;
using Ventas.Web.Models.Producto;
using Ventas.Web.Models.Producto.Request;

namespace Ventas.Web.Controllers.Extentions
{
    public static class ProductoExtention
    {
        public static BaseProductoModel ConverModelToProductoResponse(this ProductoModels pro)
        {
            return new BaseProductoModel
            {
                IdProducto = pro.IdProducto,
                CodigoBarra = pro.CodigoBarra,
                Marca = pro.Marca,
                Descripcion = pro.Descripcion,
                Stock = pro.Stock,
                UrlImagen = pro.UrlImagen,
                NombreImagen = pro.NombreImagen,
                Precio = pro.Precio,
                EsActivo = pro.EsActivo,
                FechaRegistro = pro.FechaRegistro
            };
        }

        public static ProductoAddDto ConverAddRequestToAddDto(this ProductoAddRequest productoAdd)
        {
            return new ProductoAddDto()
            {
                CodigoBarra = productoAdd.CodigoBarra,
                Marca = productoAdd.Marca,
                Descripcion = productoAdd.Descripcion,
                Stock = productoAdd.Stock,
                UrlImagen = productoAdd.UrlImagen,
                NombreImagen = productoAdd.NombreImagen,
                Precio = productoAdd.Precio,
                ChangeUser = productoAdd.ChangeUser,
                ChangeDate = productoAdd.ChangeDate
            };

        }

        public static ProductoUpdateRequest ConverProductoToUpdateRequest(this ProductoModels productoUpdate)
        {
            return new ProductoUpdateRequest()
            {
                IdProducto = productoUpdate.IdProducto,
                CodigoBarra = productoUpdate.CodigoBarra,
                Marca = productoUpdate.Marca,
                Descripcion = productoUpdate.Descripcion,
                Stock = productoUpdate.Stock,
                UrlImagen = productoUpdate.UrlImagen,
                NombreImagen = productoUpdate.NombreImagen,
                Precio = productoUpdate.Precio
            };
        }

        //api
        public static ProductoUpdateRequest ConverProductoToUpdateRequest(this BaseProductoModel productoUpdate)
        {
            return new ProductoUpdateRequest()
            {
                IdProducto = productoUpdate.IdProducto,
                CodigoBarra = productoUpdate.CodigoBarra,
                Marca = productoUpdate.Marca,
                Descripcion = productoUpdate.Descripcion,
                Stock = productoUpdate.Stock,
                UrlImagen = productoUpdate.UrlImagen,
                NombreImagen = productoUpdate.NombreImagen,
                Precio = productoUpdate.Precio
            };
        }

        public static ProductoUpdateDto ConverUpdateRequestToUpdateDto(this ProductoUpdateRequest productoUpdate)
        {
            return new ProductoUpdateDto()
            {
                IdProducto = productoUpdate.IdProducto,
                CodigoBarra = productoUpdate.CodigoBarra,
                Marca = productoUpdate.Marca,
                Descripcion = productoUpdate.Descripcion,
                Stock = productoUpdate.Stock,
                UrlImagen = productoUpdate.UrlImagen,
                NombreImagen = productoUpdate.NombreImagen,
                Precio = productoUpdate.Precio,
                ChangeUser = productoUpdate.ChangeUser,
                ChangeDate = productoUpdate.ChangeDate
            };
        }

        public static ProductoRemoveDto ConverRemoveDtoToRemoveRequest(this ProductoRemoveRequest productoRemove)
        {
            return new ProductoRemoveDto()
            {
                IdProducto = productoRemove.IdProducto,
                ChangeUser = productoRemove.ChangeUser,
                ChangeDate = productoRemove.ChangeDate
            };
        }
    }
}
