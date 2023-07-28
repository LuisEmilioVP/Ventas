using System;
using Microsoft.Extensions.Logging;
using Ventas.Application.Contract;
using Ventas.Application.Core;
using Ventas.Application.Dtos.Venta;
using Ventas.Application.Extensions;
using Ventas.Application.Helpers;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Application.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository ventaRepository;
        private readonly ILogger<VentaService> logger;

        public VentaService(IVentaRepository ventaRepository,
                            ILogger<VentaService> logger)
        {
            this.ventaRepository = ventaRepository;
            this.logger = logger;
        }

        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var ventas = this.ventaRepository.GetAllVenta();
                result.Data = ventas;
                result.Message = "Ventas obtenidas exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ventas";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var venta = this.ventaRepository.GetVentaById(id);
                result.Data = venta;
                result.Message = "Venta obtenida exitosamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(VentaAddDto model)
        {
            ServiceResult result = VentaValidationHelper.ValidateVentaData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var venta = model.ConvertDtoToAddEntity();
                this.ventaRepository.Add(venta);

                result.Message = "Venta agregada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(VentaUpdateDto model)
        {
            ServiceResult result = VentaValidationHelper.ValidateVentaData(model);

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var venta = model.ConvertDtoToUpdateEntity();
                this.ventaRepository.Update(venta);

                result.Message = "Venta actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(VentaRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                this.ventaRepository.Remove(new Venta()
                {
                    IdVenta = model.IdVenta,
                    UserDeleted = model.ChangeUser,
                    DeletedDate = model.ChangeDate,
                    Deleted = model.Deleted
                });

                result.Message = "Venta eliminada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al intentar eliminar la venta";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

    }
}
