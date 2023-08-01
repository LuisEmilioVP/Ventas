using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dto.Venta;
using Ventas.Application.Extentions;
using Ventas.Application.Validations;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository VentaRepository;
        private readonly ILogger<VentaService> logger;

        public VentaService(IVentaRepository VentaRepository, 
                                     ILogger<VentaService> logger)
        {
            this.VentaRepository = VentaRepository;
            this.logger = logger;
        }

        
        public ServiceResult Get()
        {
           ServiceResult result = new ServiceResult();
            try
            {
                var Vent = this.VentaRepository.GetAllVenta();
                result.Data = Vent;
                result.Message = "Ventas obtenidos exitosamente";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al tener al Ventas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var Vent = this.VentaRepository.GetVentaById(id);
                result.Data = Vent;
                result.Message = "Venta obtenido exitosamente";
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error al tener al Suplidores";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult Save(VentaAddDto model)
        {
            ServiceResult result = VentaValidations.ValidateVenta(model);
          
            if (!result.Success)
            {
                return result;
            }

            try
            {
                var Venta = model.ConvertDtoAddToEntity();
                this.VentaRepository.Add(Venta);

                result.Message = "Venta agregado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el Venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;


        }

        public ServiceResult Update(VentaUpdateDto model)
        {
            ServiceResult result = VentaValidations.ValidateVenta(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var Venta = model.ConvertDtoUpdateToEntity();
                this.VentaRepository.Update(Venta);

                result.Message = "El Venta ha sido actualizado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error al actualizar el Venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Delete(VentaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.VentaRepository.Remove(new Venta()
                {

                    IdVenta = model.IdVenta,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
            });

                result.Message = "Venta ha sido eliminado satisfactoriamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error al eliminar el Venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

 
    }

    
}
