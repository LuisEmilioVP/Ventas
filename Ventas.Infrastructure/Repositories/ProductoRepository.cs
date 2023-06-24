using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Extentions;
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
                producto = this.context.Producto
                    .Where(pro => !pro.Deleted)
                    .Select(pro => new ProductoModels()

                    {
                        CodigoBarra = pro.CodigoBarra,
                        Marca = pro.Marca,
                        Descripcion = pro.Descripcion,
                        Stock = pro.Stock,
                        UrlImagen = pro.UrlImagen,
                        NombreImagen = pro.NombreImagen,
                        Precio = pro.Precio,
                        EsActivo = pro.EsActivo,
                        FechaRegistro = pro.FechaRegistro
                    }).ToList();
            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo los productos", e.ToString());
            }

            return producto;
        }

        public ProductoModels GetProductoById(int idproducto)
        {
            ProductoModels productoModels = new ProductoModels();
            try
            {
                if (!base.Exists(pro => pro.IdProducto == idproducto))
                    throw new ProductoNotFoundException("Producto no encontrado en la base de datos");

                productoModels = base.GetEntity(idproducto).ConvertUserEntityToModel();
                this.logger.LogInformation($"Obteniendo un usuario: {idproducto}");
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error al cargar el producto {e.Message}", e.ToString());
                throw new DbConnectionException($"Error de Conexión: {e.Message}");
            }
            
            return productoModels;
        }

        public override void Add(Producto entity)
        {
            try
            {
                if (this.Exists(pro => pro.CodigoBarra == entity.CodigoBarra)) 
                {
                    throw new ProductoExceptions("Este codigo de barra ya existe");

                }

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nuevo codigo de barra agregado:{entity.CodigoBarra}");
            }
            catch (ProductoExceptions e)
            {
                this.logger.LogError($"Error al agregar el codigo de barra: {e.Message}", e.ToString());
                throw;
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error al cargar el codigo de barra{e.Message}", e.ToString());
                throw new DbConnectionException($"Error de Conexión: {e.Message}");
            }
        }
      
        public override void Update(Producto entity)
        {
            try
            {
               Producto ProductoToUpdate = this.GetEntity(entity.IdProducto)
                    ?? throw new ProductoNotFoundException(
                        "Producto no encontrado en la base de datos");

                ProductoToUpdate.IdProducto = entity.IdProducto;
                ProductoToUpdate.CodigoBarra = entity.CodigoBarra;
                ProductoToUpdate.Marca = entity.Marca;
                ProductoToUpdate.Descripcion = entity.Descripcion;
                ProductoToUpdate.Stock = entity.Stock;
                ProductoToUpdate.Precio = entity.Precio;
                ProductoToUpdate.UrlImagen = entity.UrlImagen;
                ProductoToUpdate.NombreImagen = entity.NombreImagen;
                ProductoToUpdate.FechaRegistro = entity.FechaRegistro;
                ProductoToUpdate.UserMod = entity.UserMod;
                ProductoToUpdate.ModifyDate = entity.ModifyDate;

                this.context.Producto.Update(ProductoToUpdate);         
                this.context.SaveChanges();
            }
            catch (ProductoNotFoundException ex)
            {
                this.logger.LogError($"Error al actualizar el producto {ex.Message}", ex.ToString());
            }
             catch (Exception e)
            {
                this.logger.LogError($"Error al cargar el producto{e.Message}", e.ToString());
                throw new DbConnectionException($"Error de Conexión: {e.Message}");
            }
        
        }

        public override void Remove(Producto entity)
        {
            try
            {

                Producto ProductoToRemove = this.GetEntity(entity.IdProducto)
                 ?? throw new ProductoNotFoundException(
                        "Producto no encontrado en la base de datos");

                ProductoToRemove.IdProducto = entity.IdProducto;
                ProductoToRemove.UserDeleted = entity.UserDeleted;
                ProductoToRemove.DeletedDate = entity.DeletedDate;
                ProductoToRemove.Deleted = entity.Deleted;

                this.context.Update(ProductoToRemove);
                this.context.SaveChanges();
                this.logger.LogInformation("Eliminación de el producto exitosa.");
            }
            catch (ProductoExceptions e)
            {
                this.logger.LogError($"Error al borrar el producto {e.Message}", e.ToString());
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error al cargar el codigo de barra{e.Message}", e.ToString());
                throw new DbConnectionException($"Error de Conexión: {e.Message}");
            }
        }
    }
}


