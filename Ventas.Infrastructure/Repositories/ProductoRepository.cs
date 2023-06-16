using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository

    {

        private readonly ILogger<ProductoRepository> logger;
        private readonly VentasContext context;

        public ProductoRepository(
            ILogger<ProductoRepository> logger, VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }



        public List<ProductoModels> GetAllProducto()
        {
            List<ProductoModels> producto = new List<ProductoModels>();
            try
            {

                this.logger.LogInformation("Obteniendo Producto...");
                producto = this.context.Productos
                    .Where(pro => !pro.Deleted)
                    .Select(pro => new ProductoModels()

                    {
                        CodigoBarra = pro.CodigoBarra,
                        Marca = pro.Marca,
                        ProductoDescripcion = pro.ProductoDescripcion,
                        Stock = pro.Stock,
                        UrlImagen = pro.UrlImagen,
                        NombreImagen = pro.NombreImagen,
                        Precio = pro.Precio,
                        EsActivo = pro.EsActivo,
                        FechaRegistro = pro.FechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error obteniendo los productos", ex.ToString());
            }

            return producto;

        }

        public ProductoModels GetProductoById(int idproducto)
        {
            ProductoModels productoModels = new ProductoModels();
            try
            {
                this.logger.LogInformation($"Obteniendo un Producto: {idproducto}");
                Producto producto = this.GetEntity(idproducto);

                productoModels.CodigoBarra = producto.CodigoBarra;
                productoModels.Marca = producto.Marca;
                productoModels.ProductoDescripcion = producto.ProductoDescripcion;
                productoModels.Stock = producto.Stock;
                productoModels.UrlImagen = producto.UrlImagen;
                productoModels.NombreImagen = producto.NombreImagen;
                productoModels.Precio = producto.Precio;
                productoModels.EsActivo = producto.EsActivo;
                productoModels.FechaRegistro = producto.FechaRegistro;

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el producto {ex.Message}", ex.ToString());

            }
            return productoModels;
        }

        public override void Add(Producto entity)
        {
            base.Add(entity);
        }


        public override void Update(Producto entity)
        {

            try
            {
                Producto ProductoToUpdate = this.GetEntity(entity.IdProducto);

                ProductoToUpdate.IdProducto = entity.IdProducto;
                ProductoToUpdate.CodigoBarra = entity.CodigoBarra;
                ProductoToUpdate.Marca = entity.Marca;
                ProductoToUpdate.ProductoDescripcion = entity.ProductoDescripcion;
                ProductoToUpdate.Stock = entity.Stock;
                ProductoToUpdate.Precio = entity.Precio;
                ProductoToUpdate.UrlImagen = entity.UrlImagen;
                ProductoToUpdate.NombreImagen = entity.NombreImagen;
                ProductoToUpdate.FechaRegistro = entity.FechaRegistro;
                ProductoToUpdate.UserMod = entity.UserMod;
                ProductoToUpdate.ModifyDate = entity.ModifyDate;

                this.context.Productos.Update(ProductoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar el producto {ex.Message}", ex.ToString());
            }
        }

        public override void Remove(Producto entity)
        {
            try
            {
                Producto ProductoToRemove = this.GetEntity(entity.IdProducto);

                ProductoToRemove.IdProducto = entity.IdProducto;
                ProductoToRemove.UserDeleted = entity.UserDeleted;
                ProductoToRemove.DeletedDate = entity.DeletedDate;
                ProductoToRemove.Deleted = entity.Deleted;

                this.context.Update(ProductoToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al borrar el producto {ex.Message}", ex.ToString());
            }
        }

        List<ProductoModels> IProductoRepository.GetProductoById(int idproducto)
        {
            throw new NotImplementedException();
        }
    }
}


