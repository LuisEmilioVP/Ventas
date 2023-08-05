using System;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class ProductoExtension
    {
        public static ProductoModels ConvertProductoEntityToModel(this Producto pro)
        {
            ProductoModels ProductoModel = new ProductoModels()
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

            return ProductoModel;
        }

        public static Producto ConvertProductoCreateToEntity(this Producto pro)
        {
            return new Producto()
            {
                CodigoBarra = pro.CodigoBarra,
                Marca = pro.Marca,
                Descripcion = pro.Descripcion,
                Stock = pro.Stock,
                UrlImagen = pro.UrlImagen,
                NombreImagen = pro.NombreImagen,
                Precio = pro.Precio,
                EsActivo = pro.EsActivo = true,
                FechaRegistro = pro.FechaRegistro = DateTime.Now,
                CreationUser = pro.CreationUser,
                CreationDate = pro.CreationDate = DateTime.Now,
            };
        }

        public static Producto ConvertProductoUpdateToEntity(this Producto productoToUpdate,
                                                           Producto pro)
        {
            productoToUpdate.IdProducto = pro.IdProducto;
            productoToUpdate.CodigoBarra = pro.CodigoBarra;
            productoToUpdate.Marca = pro.Marca;
            productoToUpdate.Descripcion = pro.Descripcion;
            productoToUpdate.Stock = pro.Stock;
            productoToUpdate.UrlImagen = pro.UrlImagen;
            productoToUpdate.NombreImagen = pro.NombreImagen;
            productoToUpdate.Precio = pro.Precio;
            productoToUpdate.EsActivo = pro.EsActivo = true;
            productoToUpdate.FechaRegistro = pro.FechaRegistro = DateTime.Now;
            productoToUpdate.UserMod = pro.UserMod;
            productoToUpdate.ModifyDate = pro.ModifyDate = DateTime.Now;

            return productoToUpdate;
        }

        public static Producto ConvertProductoRemoveToEntity(this Producto ProductoToRemove,
                                                          Producto pro)
        {
            ProductoToRemove.EsActivo = false;
            ProductoToRemove.Deleted = true;
            ProductoToRemove.DeletedDate = pro.DeletedDate = DateTime.Now;

            return ProductoToRemove;
        }

    }
}
