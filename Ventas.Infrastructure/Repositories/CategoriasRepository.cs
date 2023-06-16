using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repositories
{
    public class CategoriasRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ILogger<CategoriasRepository> logger;
        private readonly VentasContext context;

        public CategoriasRepository(ILogger<CategoriasRepository> logger,
            VentasContext ventas) : base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

        public List<CategoriaModels> GetAllCategory()
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Categorias");
                categorias = this.context.Categoria
                    .Where(ca => ca.EsActivo == true)
                    .Select(cat => new CategoriaModels()
                    {
                        Descripcion = cat.Descripcion,
                        EsActivo = cat.EsActivo,
                        FechaRegistro = cat.FechaRegistro,
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Categorias {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categorias;
        }

        public CategoriaModels GetCategoryById(int id)
        {
            CategoriaModels categoriaModels = new CategoriaModels();
            try
            {
                this.logger.LogInformation("Obteniendo Categorias");
                Categoria categoria = this.GetEntity(id);

                categoriaModels.Descripcion = categoria.Descripcion;
                categoriaModels.EsActivo = categoria.EsActivo;
                categoriaModels.FechaRegistro = categoria.FechaRegistro;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar Categorias {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }

            return categoriaModels;
        }

        public override void Add(Categoria entity)
        {
            try
            {
                if (this.Exists(cat => cat.Descripcion == entity.Descripcion))
                    throw new CategoriaExceptions("¡La Categoria ya existe!");

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nueva Categoria insertada: {entity.Descripcion}");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al agregar Categoria: {ex.Message}", ex.ToString());
                throw;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoria {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Update(Categoria entity)
        {
            try
            {
                Categoria categoriaToUpdate = this.GetEntity(entity.IdCategoria)
                    ?? throw new CategoriaNotFoundException(
                        "Categoria no encontrada en la base de datos");

                categoriaToUpdate.IdCategoria = entity.IdCategoria;
                categoriaToUpdate.Descripcion = entity.Descripcion;
                categoriaToUpdate.EsActivo = entity.EsActivo;
                categoriaToUpdate.FechaRegistro = entity.FechaRegistro;
                categoriaToUpdate.UserMod = entity.UserMod;
                categoriaToUpdate.ModifyDate = entity.ModifyDate;

                this.context.Categoria.Update(categoriaToUpdate);
                this.SaveChanges();
                this.logger.LogInformation("Actualización de Categoria exitosa.");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al actualizar Categoria: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar Categoria: {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Remove(Categoria entity)
        {
            try
            {
                Categoria categoriaToRemove = this.GetEntity(entity.IdCategoria)
                 ?? throw new CategoriaNotFoundException(
                     "Categoria no encontrada en la base de datos");

                categoriaToRemove.UserDeleted = entity.UserDeleted;
                categoriaToRemove.DeletedDate = entity.DeletedDate;
                categoriaToRemove.Deleted = entity.Deleted;

                this.context.Update(categoriaToRemove);
                this.context.SaveChanges();
                this.logger.LogInformation("Eliminación de categoria exitosa.");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al eliminar categoria: {ex.Message}");
                throw;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al eliminar categoria: {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }
    }
}
