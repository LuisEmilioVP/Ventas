using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Categoria;
using Ventas.Application.Extentions;
using Ventas.Application.Helpers;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository categoriarepository;
        private readonly ILogger<CategoriaService> logger;

        public CategoriaService(ICategoriaRepository categoriaRepository, 
                                 ILogger<CategoriaService> logger) 
        {
            this.categoriarepository = categoriaRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.categoriarepository.GetAllCategory();
                result.Data = cat;
                result.Message = "Categorías obtenidas exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorías";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.categoriarepository.GetCategoryById(id);
                result.Data = cat;
                result.Message = "Categoría obtenida exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(CategoriaAddDto model)
        {
            ServiceResult result = CategoryValidationHelper.ValidateCategoryData(model);

            if(!result.Success) 
            {
                return result;
            }

            try
            {
                var categoria = model.ConvertDtoAddToEntity();
                this.categoriarepository.Add(categoria);

                result.Message = "Categoría agregado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(CategoriaUpdateDto model)
        {
            ServiceResult result = CategoryValidationHelper.ValidateCategoryData(model);

            if(!result.Success)
            {
                return result;
            }

            try
            {
                var categoria = model.ConvertDtoUpdateToEntity();
                this.categoriarepository.Update(categoria);

                result.Message = "Categoría actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(CategoriaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.categoriarepository.Remove(new Categoria()
                {
                    IdCategoria = model.IdCategoria,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
                });

                result.Message = "Categoría eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al intentar eliminar categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
