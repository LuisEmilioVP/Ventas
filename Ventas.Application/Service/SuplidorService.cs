using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dto.Suplidor;
using Ventas.Application.Extentions;
using Ventas.Application.Validations;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class SuplidorService : ISuplidorService
    {
        private readonly ISuplidorRepository suplidorRepository;
        private readonly ILogger<SuplidorService> logger;

        public SuplidorService(ISuplidorRepository suplidorRepository, 
                                     ILogger<SuplidorService> logger)
        {
            this.suplidorRepository = suplidorRepository;
            this.logger = logger;
        }

        
        public ServiceResult Get()
        {
           ServiceResult result = new ServiceResult();
            try
            {
                var supli = this.suplidorRepository.GetAllSuplidor();
                result.Data = supli;
                result.Message = "Suplidores obtenidos exitosamente";
            }
            catch (SuplidorException supl)
            {
                result.Success = false;
                result.Message = supl.Message;
                this.logger.LogError($"Algo ha salido mal {result.Message}");
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al tener al Suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = SuplidorValidations.ValidateIdSuplidor(id);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var suplis = this.suplidorRepository.GetsuplidorById(id);
                result.Data = suplis;
                result.Message = $"Suplidor obtenido exitosamente:{id}";
            }
            catch (SuplidorException supl)
            {
                result.Success = false;
                result.Message = supl.Message;
                this.logger.LogError($"Algo ha salido mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al tener al Suplidor: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(SuplidorAddDto model)
        {
            ServiceResult result = SuplidorValidations.ValidateSuplidorAdd(model);
          
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var suplidor = model.ConvertDtoAddToEntity();
                this.suplidorRepository.Add(suplidor);

                result.Message = "Suplidor agregado satisfactoriamente";
            }
            catch (SuplidorException supl)
            {
                result.Success = false;
                result.Message = supl.Message;
                this.logger.LogError($"Algo ha salido mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el suplidor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;


        }

        public ServiceResult Update(SuplidorUpdateDto model)
        {
            ServiceResult result = SuplidorValidations.ValidateSuplidorUpdate(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var suplidor = model.ConvertDtoUpdateToEntity();
                this.suplidorRepository.Update(suplidor);

                result.Message = "El suplidor ha sido actualizado satisfactoriamente";
            }
            catch (SuplidorException supl)
            {
                result.Success = false;
                result.Message = supl.Message;
                this.logger.LogError($"Algo ha salido mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error al actualizar el suplidor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Delete(SuplidorRemoveDto model)
        {
            ServiceResult result = SuplidorValidations.ValidateSuplidorRemove(model);

            try
            {
                var suplidor = model.ConvertRemoveDtoToEntity();
                this.suplidorRepository.Remove(suplidor);

                result.Message = "El suplidor ha sido eliminado satisfactoriamente";
            }
            catch (SuplidorException supl)
            {
                result.Success = false;
                result.Message = supl.Message;
                this.logger.LogError($"Algo ha salido mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el suplidor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }


    }

    
}
