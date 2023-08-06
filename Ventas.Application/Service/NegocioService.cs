using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Negocio;
using Ventas.Application.Extensions;
using Ventas.Application.Validations;
using Ventas.Infrastructure.Exceptions;
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
                var negocicos = this.NegocioRepository.GetAllNegocio();
                result.Data = negocicos;
                result.Message = "Negocios obtenidos exitosamente";
            }
            catch (NegocioExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los negocios";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = NegocioValidator.ValidateIdNegocio(id);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var nego = this.NegocioRepository.GetNegocio(id);
                result.Data = nego;
                result.Message = $"Negocio obtenido exitosamente. Id de usuario: {id}";
            }
            catch (NegocioExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error al obtener usuario Id: {id}";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(NegocioRemoveDto model)
        {
            ServiceResult result = NegocioValidator.ValidateNegocioRemove(model);

            try
            {
                var negocio = model.ConvertRemoveDtoToEntity();
                this.NegocioRepository.Remove(negocio);

                result.Message = "Negocio eliminado correctamente";
            }
            catch (NegocioExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
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
            ServiceResult result = NegocioValidator.ValidateNegocioAdd(model);

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
            catch (NegocioExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregando el Negocio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(NegocioUpdateDto model)
        {
            ServiceResult result = NegocioValidator.ValidateNegocioUpdate(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var usuario = model.ConvertDtoUpdateToEntity();
                this.NegocioRepository.Update(usuario);

                result.Message = "Negocio actualizado correctamente";
            }
            catch (NegocioExceptions uex)
            {
                result.Success = false;
                result.Message = uex.Message;
                this.logger.LogError($"Algo salió mal {result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el negocio";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}