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
            this.logger.LogInformation("Se agregará una nueva categoría…");
            try
            {
                if (entity == null)
                    throw new CategoriaExceptions("Una categoría no puede ser nula");

                if (this.Exists(cat => cat.Descripcion == entity.Descripcion && entity.EsActivo == true))
                    throw new CategoriaExceptions($"¡La Categoría {entity.Descripcion} ya existe!");

                entity.ConvertCategoriaCreateToEntity();

                base.Add(entity);
                this.logger.LogInformation($"Nueva Categoría insertada: {entity.Descripcion}");
                base.SaveChanges();
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
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
                this.logger.LogInformation($"Se actualizará la categoría con el, Id: {entity.IdCategoria}");

                Categoria categoriaToUpdate = base.GetEntity(entity.IdCategoria)
                    ?? throw new CategoriaNotFoundException(
                        "Usuario no encontrado en la base de datos");

                if (categoriaToUpdate.EsActivo == false && categoriaToUpdate.Deleted == false)
                    throw new CategoriaExceptions("La categoría a actualizar ya está eliminada");

                categoriaToUpdate.ConvertCategoriaUpdateToEntity(entity);

                base.Update(categoriaToUpdate);
                this.logger.LogInformation($"La categoria de Id: {entity.IdCategoria} ha sido actualizada");
                this.SaveChanges();
            }
            catch (CategoriaExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar Categoría: {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de Conexión: {ex.Message}");
            }
        }

        public override void Remove(Categoria entity)
        {
            try
            {
                this.logger.LogInformation($"Se eliminará la categoría con el, Id: {entity.IdCategoria}");

                Categoria categoriaToRemove = this.GetEntity(entity.IdCategoria)
                 ?? throw new CategoriaNotFoundException(
                     "Categoría no encontrada en la base de datos");

                if (categoriaToRemove.EsActivo == false)
                    throw new CategoriaExceptions("La categoria ya ha sido eliminado");

                categoriaToRemove.ConvertCategoriaRemoveToEntity(entity);

                this.context.Update(categoriaToRemove);
                this.logger.LogInformation($"La categoría de Id: {entity.IdCategoria} ha sido eliminado");
                this.context.SaveChanges();
            }
            catch(CategoriaExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
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
                
                List<Categoria> category = base.GetEntities()
                    .Where(cat => !cat.Deleted && cat.EsActivo == true).ToList()
                    ?? throw new CategoriaNotFoundException(
                        "Categoría no encontrado en la base de datos");

                foreach (Categoria categoria in category)
                {
                    CategoriaModels categoriaModels = categoria.ConvertCategoryEntityToModel();
                    categorias.Add(categoriaModels);
                }
            }
            catch (CategoriaExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
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
                this.logger.LogInformation($"Obteniendo Categoría de Id: {categoryId}");

                Categoria category = context.Categoria.FirstOrDefault(cat => cat.IdCategoria == categoryId
                && cat.EsActivo == true)
                    ?? throw new CategoriaNotFoundException(
                        $"Categoría de id: {categoryId} no encontrado en la base de datos");

                categoriaModels = category.ConvertCategoryEntityToModel();
                this.logger.LogInformation($"Obteniendo la categoría de Id: {categoryId}");
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el categoría {ex.Message}", ex.ToString());
                throw new CDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return categoriaModels;
        }
    }
}
