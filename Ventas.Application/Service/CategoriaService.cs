using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Categoria;
using Ventas.Application.Extentions;
using Ventas.Application.Validations;
using Ventas.Infrastructure.Exceptions;
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
            catch (CategoriaExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
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
            ServiceResult result = CategoriaValidator.ValidateIdCategoria(id);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var cat = this.categoriarepository.GetCategoryById(id);
                result.Data = cat;
                result.Message = $"Categoría obtenida exitosamente. Id de categoría: {id}";
            }
            catch (CategoriaExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo categoría de Id: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(CategoriaAddDto model)
        {
            ServiceResult result = CategoriaValidator.ValidateCategoriaAdd(model);

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
            catch (CategoriaExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
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
            ServiceResult result = CategoriaValidator.ValidateCategoriaUpdate(model);

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
            catch (CategoriaExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
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
            ServiceResult result = CategoriaValidator.ValidateCategoriaRemove(model);

            try
            {
                var category = model.ConvertRemoveDtoToEntity();
                this.categoriarepository.Remove(category);

                result.Message = "Categoría eliminado correctamente";
            }
            catch (CategoriaExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
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
