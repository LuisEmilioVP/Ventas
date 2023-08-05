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
                this.logger.LogInformation("Obteniendo Productos...");

                List<Producto> pro = base.GetEntities()
                    .Where(pro => !pro.Deleted && pro.EsActivo == true).ToList();

                if (pro == null)
                    throw new ProductoNotFoundException(
                        "Producto no encontrado en la base de datos");

                foreach (Producto productos in pro)
                {
                    ProductoModels productoModels = productos.ConvertProductoEntityToModel();
                    producto.Add(productoModels);
                }
            }
            catch (Exception e)
            {
                this.logger.LogError("Error obteniendo los productos", e.ToString());
                throw new DbConnectionException($"Error de conexión: {e.Message}");
            }

            return producto;
        }

        public ProductoModels GetProductoById(int idproducto)
        {
            ProductoModels productoModels = new ProductoModels();
            try
            {
                Producto pro = context.Producto.FirstOrDefault(pro => pro.IdProducto == idproducto
                && pro.EsActivo == true);

                if (pro == null)
                    throw new ProductoNotFoundException("Producto no encontrado en la base de datos");

                productoModels = pro.ConvertProductoEntityToModel();

                this.logger.LogInformation($"Obteniendo un producto: {idproducto}");
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
            this.logger.LogInformation("Se agregará un nuevo prdoucto…");

            try
            {
                string? codigoBarra = entity.CodigoBarra;

                if (this.Exists(pro => pro.CodigoBarra == entity.CodigoBarra)) 
                {
                    throw new ProductoExceptions($"¡El correo: {codigoBarra} ya existe!");

                }

                entity.ConvertProductoCreateToEntity();

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nuevo codigo de barra agregado:{entity.CodigoBarra}");
            }
            catch (ProductoExceptions e)
            {
                this.logger.LogError($"Algo salió mal: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                this.logger.LogError($"Error al agregar el producto{e.Message}", e.ToString());
                throw new DbConnectionException($"Error de Conexión: {e.Message}");
            }
        }
      
        public override void Update(Producto entity)
        {
            try
            {
                this.logger.LogInformation($"Se actualizará el producto con el, Id: {entity.IdProducto}");

                Producto productoToUpdate = base.GetEntity(entity.IdProducto)
                    ?? throw new ProductoNotFoundException(
                        "Producto no encontrado en la base de datos");

                if (productoToUpdate.EsActivo == false && productoToUpdate.Deleted == true)
                    throw new ProductoExceptions("El producto a actualizar está eliminado");

                productoToUpdate.ConvertProductoUpdateToEntity(entity);

                base.Update(productoToUpdate);
                this.logger.LogInformation($"El producto de Id: {entity.IdProducto} ha sido actualizado");
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

                this.logger.LogInformation($"Se eliminara el producto con el, Id: {entity.IdProducto}");

                Producto ProductoToRemove = base.GetEntity(entity.IdProducto)
                    ?? throw new ProductoNotFoundException(
                        "Producto no encontrado en la base de datos");

                if (ProductoToRemove.EsActivo == false)
                    throw new ProductoExceptions("Este producto ya esta eliminado");

                ProductoToRemove.ConvertProductoRemoveToEntity(entity);

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


