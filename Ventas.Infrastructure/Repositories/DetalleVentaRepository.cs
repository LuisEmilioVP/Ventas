using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;
using Ventas.Infrastructure.Extensions;
using DetalleVentas.Infrastructure;
using Ventas.Infrastructure.Models.cs;

namespace DetalleVentas.Infrastructure.Repositories
{
    public class DetalleVentaRepository : BaseRepository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly ILogger<DetalleVentaRepository> logger;
        private readonly VentasContext context;

        public DetalleVentaRepository(ILogger<DetalleVentaRepository> logger, VentasContext ventas) : base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

        List<Venta> IDetalleVentaRepository.GetAllDetalleVentas()
        {
            List<DetalleVenta> ventas = new List<DetalleVenta>();
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

        public DetalleVentaModels GetDetalleVentaById(int detalleventaId)
        {
            VentaModels venta = new VentaModels();

            try
            {
                if (!base.Exists(v => v.IdVenta == detalleventaId))
                    throw new DetalleVentaNotFoundException("Venta no encontrada en la base de datos");

                detalleventa = base.GetEntity(detalleventaId).ConvertVentaEntityToModel();
                this.logger.LogInformation($"Obteniendo una venta: {detalleventaId}");
            }
            catch (DetalleVentaNotFoundException ex)
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


   
    }
}