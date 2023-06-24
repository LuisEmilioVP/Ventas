using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Extentions;
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

        public override void Add(Categoria entity)
        {
            try
            {
                if (this.Exists(cat => cat.Descripcion == entity.Descripcion))
                    throw new CategoriaExceptions("¡La Categoría ya existe!");

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nueva Categoría insertada: {entity.Descripcion}");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al agregar Categoría: {ex.Message}", ex.ToString());
                throw;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoría {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Update(Categoria entity)
        {
            try
            {
                Categoria categoriaToUpdate = this.GetEntity(entity.IdCategoria)
                    ?? throw new CategoriaNotFoundException(
                        "Categoría no encontrada en la base de datos");

                categoriaToUpdate.IdCategoria = entity.IdCategoria;
                categoriaToUpdate.Descripcion = entity.Descripcion;
                categoriaToUpdate.EsActivo = entity.EsActivo;
                categoriaToUpdate.FechaRegistro = entity.FechaRegistro;
                categoriaToUpdate.UserMod = entity.UserMod;
                categoriaToUpdate.ModifyDate = entity.ModifyDate;

                this.context.Categoria.Update(categoriaToUpdate);
                this.SaveChanges();
                this.logger.LogInformation("Actualización de Categoría exitosa.");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al actualizar Categoría: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar Categoría: {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Remove(Categoria entity)
        {
            try
            {
                Categoria categoriaToRemove = this.GetEntity(entity.IdCategoria)
                 ?? throw new CategoriaNotFoundException(
                     "Categoría no encontrada en la base de datos");

                categoriaToRemove.IdCategoria = entity.IdCategoria;
                categoriaToRemove.UserDeleted = entity.UserDeleted;
                categoriaToRemove.DeletedDate = entity.DeletedDate;
                categoriaToRemove.Deleted = entity.Deleted;

                this.context.Update(categoriaToRemove);
                this.context.SaveChanges();
                this.logger.LogInformation("Eliminación de categoría exitosa.");
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Error al eliminar categoría: {ex.Message}");
                throw;
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al eliminar categoría: {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public List<CategoriaModels> GetAllCategory()
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Categorías...");
                categorias = this.context.Categoria
                    .Where(ca => !ca.Deleted)
                    .Select(cat => new CategoriaModels()
                    {
                        Descripcion = cat.Descripcion,
                        EsActivo = cat.EsActivo,
                        FechaRegistro = cat.FechaRegistro,
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Categorías {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categorias;
        }

        public CategoriaModels GetCategoryById(int categoryId)
        {
            CategoriaModels categoriaModels = new CategoriaModels();

            try
            {
                if (!base.Exists(ca => ca.IdCategoria == categoryId))
                    throw new UsuarioNotFoundException(
                        "Categoría no encontrado en la base de datos");

                categoriaModels = base.GetEntity(categoryId).ConvertCategoryEntityToModel();
                this.logger.LogInformation($"Obteniendo una Categoría: {categoryId}");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el categoría {ex.Message}", ex.ToString());
                throw new UsuarioExceptions("Categoría no existe...");
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categoriaModels;
        }
    }
}
