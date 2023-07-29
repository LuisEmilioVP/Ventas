using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dto.Suplidor;
using Ventas.Application.Extentions;
using Ventas.Application.Validations;
using Ventas.Domain.Entities;
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
            ServiceResult result = new ServiceResult();

            try
            {
                var suplis = this.suplidorRepository.GetsuplidorById(id);
                result.Data = suplis;
                result.Message = "Suplidor obtenido exitosamente";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al tener al Suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(SuplidorAddDto model)
        {
            ServiceResult result = SuplidorValidations.ValidateSuplidor(model);
          
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
            ServiceResult result = SuplidorValidations.ValidateSuplidor(model);

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
            ServiceResult result = new ServiceResult();

            try
            {
                this.suplidorRepository.Remove(new Suplidor()
                {

                    IdSuplidor = model.IdSuplidor,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
            });

                result.Message = "El suplidor ha sido eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error al eliminar el suplidor";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

 
    }

    
}
