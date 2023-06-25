using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;
using Ventas.Infrastructure;

namespace Ventas.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly ILogger<VentaRepository> logger;
        private readonly VentasContext context;

        public VentaRepository(ILogger<VentaRepository> logger, VentasContext ventas) : base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

    List<Venta> IVentaRepository.GetAllVentas()
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                this.logger.LogInformation("Obteniendo ventas...");
                ventas = this.context.Venta
                    .Where(v => !v.Deleted)
                    .Select(v => new VentaModels()
                    {
                        NumeroVenta = v.numeroVenta,
                        IdUsuario = v.idUsuario,
                        DocumentoCliente = v.documentoCliente,
                        NombreCliente = v.nombreCliente,
                        SubTotal = v.subTotal,
                        ImpuestoTotal = v.impuestoTotal,
                        Total = v.Total,
                        FechaRegistro = v.fechaRegistro
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar ventas: {ex.Message}", ex.ToString());
                throw new DbConnectionException($"Error de conexión: {ex.Message}");
            }

            return ventas;
        }

        public VentaModels GetVentaById(int ventaId)
        {
            VentaModels venta = new VentaModels();

            try
            {
                if (!base.Exists(v => v.IdVenta == ventaId))
                    throw new VentaNotFoundException("Venta no encontrada en la base de datos");

                venta = base.GetEntity(ventaId).ConvertVentaEntityToModel();
                this.logger.LogInformation($"Obteniendo una venta: {ventaId}");
            }
            catch (VentaNotFoundException ex)
            {
                this.logger.LogError($"Error al cargar la venta: {ex.Message}", ex.ToString());
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar la venta: {ex.Message}", ex.ToString());
                throw new DbConnectionException($"Error de conexión: {ex.Message}");
            }

            return venta;
        }

      
        List<Venta> IVentaRepository.GetVentaById(int idVenta)
        {
            throw new NotImplementedException();
        }
    }
}