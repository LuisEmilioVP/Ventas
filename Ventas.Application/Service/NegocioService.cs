using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Negocio;
using Ventas.Application.Extensions;
using Ventas.Application.Helpers;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class NegocioService : INegocioService
    {
        private readonly INegocioRepository NegocioRepository;
        private readonly ILogger<NegocioService> logger;

        public NegocioService(INegocioRepository negocioRepository,
                              ILogger<NegocioService> logger)
        {
            this.NegocioRepository = negocioRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var negocio = this.NegocioRepository.GetAllNegocio();
                result.Data = negocio;
                result.Message = "Negocios obtenidos exitosamente";
            }

            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var cat = this.NegocioRepository.GetNegocio(id);
                result.Data = cat;
                result.Message = "Negocio obtenida exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo Negocio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(NegocioRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.NegocioRepository.Remove(new Negocio()
                {
                    idNegocio = model.idNegocio,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
                });

                result.Message = "Negocio eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al intentar eliminar Negocio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(NegocioAddDto model)
        {
            ServiceResult result = NegocioValidationHelper.ValidateNegocioData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var negocio = model.ConvertDtoAddToEntity();
                this.NegocioRepository.Add(negocio);

                result.Message = "Negocio agregado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoría";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(NegocioUpdateDto model)
        {
            ServiceResult result = NegocioValidationHelper.ValidateNegocioData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var Negocio = model.ConvertDtoUpdateToEntity();
                this.NegocioRepository.Update(Negocio);

                result.Message = "Negocio actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}