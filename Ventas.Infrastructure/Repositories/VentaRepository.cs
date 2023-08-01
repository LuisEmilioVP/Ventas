using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Extentions;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;
using static Ventas.Infrastructure.Exceptions.VentaException;

namespace Ventas.Infrastructure.Repositories
{
    public class VentaRepository : BaseRepository<Venta>, IVentaRepository
    {
        private readonly ILogger<VentaRepository> logger;
        private readonly VentasContext context;

        public VentaRepository(ILogger<VentaRepository> logger,
            VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        public List<VentaModels> GetAllVenta()
        {
            List<VentaModels> Venta = new List<VentaModels>();

            try
            {
                Venta = this.context.Venta.Where(Vent => Vent.Deleted).Select(v => new VentaModels()
                {
                    NumeroVenta = v.NumeroVenta,
                    IdUsuario = v.IdUsuario,
                    DocumentoCliente = v.DocumentoCliente,
                    NombreCliente = v.NombreCliente,
                    SubTotal = v.SubTotal,
                    ImpuestoTotal = v.ImpuestoTotal,
                    Total = v.Total,
                    FechaRegistro = v.FechaRegistro
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Se produjo un error durante el proceso de carga del suplidor", ex.ToString());
            }
            return Venta;
        }

        public VentaModels GetVentaById(int id)
        {
            VentaModels VentaModels = new VentaModels();

            try
            {
                if (!base.Exists(Vent => Vent.IdUsuario== id))
                    throw new VentaNotFoundException("Venta no encontrado");

                VentaModels = base.GetEntity(id).ConvertVentaEntityToModel();
                this.logger.LogInformation($"Obteniendo un Suplidor: {id}");
            }
            catch (Exception ex)
            {
                this.logger.LogError("Se produjo un error durante el proceso de carga del suplidor", ex.ToString());
                throw new VentaException("Suplidor no existente");
                throw new ConnectionException($"Error al conectarse con la Base de datos: {ex.Message}");
            }

            return VentaModels;
        }


        public override void Add(Venta entity)
        {
            try
            {
                if (this.Exists(Vent => Vent.NumeroVenta == entity.NumeroVenta))
                {
                    throw new VentaException("Venta existente");
                }
                base.Add(entity);
                base.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante la agregacion del Ventar");
            }
        }

        public override void Update(Venta entity)
        {
            try
            {
                Venta VentaUpdate = this.GetEntity(entity.IdUsuario);

                VentaUpdate.NumeroVenta = entity.NumeroVenta;
                VentaUpdate.IdTipoDocumentoVenta = entity.IdTipoDocumentoVenta;
                VentaUpdate.IdUsuario = entity.IdUsuario;
                VentaUpdate.DocumentoCliente = entity.DocumentoCliente;
                VentaUpdate.NombreCliente = entity.NombreCliente;
                VentaUpdate.SubTotal = entity.SubTotal;
                VentaUpdate.ImpuestoTotal = entity.ImpuestoTotal;
                VentaUpdate.Total = entity.Total;
                VentaUpdate.FechaRegistro = entity.FechaRegistro;

                VentaUpdate.UserMod = entity.UserMod;
                VentaUpdate.ModifyDate = entity.ModifyDate;

                this.context.Venta.Update(VentaUpdate);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante la actualización del Venta", ex.ToString());
            }
        }

        public override void Remove(Venta entity)
        {
            try
            {
                Venta VentaRemove = this.GetEntity(entity.IdUsuario);

                VentaRemove.UserDeleted = entity.UserDeleted;
                VentaRemove.DeletedDate = entity.DeletedDate;
                VentaRemove.Deleted = entity.Deleted;

                this.context.Venta.Update(VentaRemove);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante el eliminado del Venta");
            }
        }

           }
}
