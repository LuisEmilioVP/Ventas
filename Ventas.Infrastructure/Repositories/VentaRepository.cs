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

        public List<Venta> GetAllVentas()
        {
            List<Venta> ventas = new List<Venta>();
            try
            {
                this.logger.LogInformation("Obteniendo Ventas...");
                ventas = this.context.Venta
                    .Where(v => !v.Deleted)
                    .Select(v => new VentaModel()
                    {
                        NumeroVenta = v.NumeroVenta,
                        FechaVenta = v.FechaVenta,
                        TotalVenta = v.TotalVenta,
                        // Agrega aquí los demás campos necesarios para la venta
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Ventas: {ex.Message}", ex.ToString());
                throw new DbConnectionException($"Error de conexión: {ex.Message}");
            }

            return ventas;
        }

        public VentaModels GetVentaById(int id)
        {
            VentaModels ventaModel = new VentaModels();
            try
            {
                this.logger.LogInformation($"Obteniendo una Venta: {id}");
                Venta venta = this.GetEntity(id);

                ventaModel.NumeroVenta = venta.NumeroVenta;
                ventaModel.FechaVenta = venta.FechaVenta;
                ventaModel.TotalVenta = venta.TotalVenta;
                // Agrega aquí los demás campos necesarios para la venta
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar la venta: {ex.Message}", ex.ToString());
                throw new DbConnectionException($"Error de conexión: {ex.Message}");
            }

            return ventaModel;
        }

        public override void Add(Venta entity)
        {
            try
            {
                // Validaciones y lógica adicional antes de agregar la venta
                // ...

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nueva venta insertada: {entity.NumeroVenta}");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al agregar la venta: {ex.Message}", ex.ToString());
                throw new DbConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Update(Venta entity)
        {
            try
            {
                Venta ventaToUpdate = this.GetEntity(entity.IdVenta)
                    ?? throw new VentaNotFoundException("Venta no encontrada en la base de datos");

                ventaToUpdate.NumeroVenta = entity.NumeroVenta;
                ventaToUpdate.FechaVenta = entity.FechaVenta;
                ventaToUpdate.TotalVenta = entity.TotalVenta;
                // Actualiza los demás campos necesarios para la venta

                // Guarda los cambios en la base de datos
                base.Update(ventaToUpdate);
                base.SaveChanges();
                this.logger.LogInformation("Actualización de venta exitosa.");
            }
            catch (VentaNotFoundException ex)
            {
                this.logger.LogError($"Error al actualizar la venta: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar la venta: {ex.Message}", ex.ToString());
            }
        }
    }
}
