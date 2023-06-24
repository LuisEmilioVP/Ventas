

using Ventas.Application.Dtos.Producto;
using Ventas.Domain.Entities;

namespace Ventas.Application.Extensions
{
    public static class ProductoExtension 
    {
        public static Producto ConvertDtoAddToEntity(this ProductoAddDto productoAddDto)
        {
            return new Producto()
            {
                CodigoBarra = productoAddDto.CodigoBarra,
                Marca = productoAddDto.Marca,
                Descripcion = productoAddDto.Descripcion,
                Stock = productoAddDto.Stock,
                Precio = productoAddDto.Precio,
                UrlImagen = productoAddDto.UrlImagen,
                NombreImagen = productoAddDto.NombreImagen,
                EsActivo = productoAddDto.EsActivo,
                FechaRegistro = productoAddDto.FechaRegistro,
                CreationUser = productoAddDto.ChangeUser,
                CreationDate = productoAddDto.ChangeDate,
            };
        }
        public static Producto ConvertDtoUpdateToEntity(this ProductoUpdateDto productoUpdateDto)
        {
            return new Producto()
            {
                IdProducto = productoUpdateDto.IdProducto,
                CodigoBarra = productoUpdateDto.CodigoBarra,
                Marca = productoUpdateDto.Marca,
                Descripcion = productoUpdateDto.Descripcion,
                Stock = productoUpdateDto.Stock,
                Precio = productoUpdateDto.Precio,
                UrlImagen = productoUpdateDto.UrlImagen,
                NombreImagen = productoUpdateDto.NombreImagen,
                EsActivo = productoUpdateDto.EsActivo,
                FechaRegistro = productoUpdateDto.FechaRegistro,
                UserMod = productoUpdateDto.ChangeUser,
                ModifyDate = productoUpdateDto.ChangeDate
            };
        }

    }
}
