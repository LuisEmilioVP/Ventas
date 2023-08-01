using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;
using Ventas.Infrastructure.Exceptions;
using Ventas.Infrastructure.Extensions;

namespace Ventas.Infrastructure.Repositories
{
    public class NegocioRepository : BaseRepository<Negocio>, INegocioRepository
    {
        private readonly ILogger<NegocioRepository> logger;
        private readonly VentasContext context;

        public NegocioRepository(ILogger<NegocioRepository> logger,
           VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(Negocio entity)
        {
            try
            {
                if (this.Exists(us => us.nombre == entity.nombre))
                    throw new NegocioExceptions("¡El Negocio ya existe!");

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nuevo Negocio insertado: {entity.nombre}");
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Error al agregar Negocio: {ex.Message}", ex.ToString());
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al agregar Negocio: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

        }

        public override void Update(Negocio entity)
        {
            try
            {
                Negocio negocioToUpdate = this.GetEntity(entity.idNegocio)
                    ?? throw new NegocioNotFoundException("Negocio no encontrado en la base de datos");

                negocioToUpdate.idNegocio = entity.idNegocio;
                negocioToUpdate.urlLogo = entity.urlLogo;
                negocioToUpdate.nombreLogo = entity.nombreLogo;
                negocioToUpdate.numeroDocumento = entity.numeroDocumento;
                negocioToUpdate.nombre = entity.nombre;
                negocioToUpdate.correo = entity.correo;
                negocioToUpdate.direccion = entity.direccion;
                negocioToUpdate.porcentajeImpuesto = entity.porcentajeImpuesto;
                negocioToUpdate.simboloMoneda = entity.simboloMoneda;
                negocioToUpdate.UserMod = 1;//entity.UserMod;
                negocioToUpdate.ModifyDate = DateTime.Now;


                this.context.Update(negocioToUpdate);
                this.context.SaveChanges();
                this.logger.LogInformation("Actualización de usuario exitosa.");
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Error al actualizar usuario: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar usuario: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Remove(Negocio entity)
        {
            try
            {
                Negocio negocioToRemove = this.GetEntity(entity.idNegocio)
                      ?? throw new NegocioNotFoundException("Negocio no encontrado en la base de datos");

                negocioToRemove.Deleted = entity.Deleted;
                negocioToRemove.UserDeleted = entity.UserDeleted;
                negocioToRemove.DeletedDate = entity.DeletedDate;

                this.context.Update(negocioToRemove);
                this.context.SaveChanges();
                this.logger.LogInformation("Eliminación de Negocio exitosa.");
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Error al eliminar Negocio: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al eliminar Negocio: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }


        }

        public NegocioModel GetNegocio(int idNegocio)
        {
            NegocioModel negociomodel = new NegocioModel();

            try
            {
                if (!base.Exists(ne => ne.idNegocio == idNegocio))
                    throw new NegocioNotFoundException("Negocio no ha sido encontrado en la base de datos");

                negociomodel = base.GetEntity(idNegocio).ConvertUserEntityToModel();
                this.logger.LogInformation($"Obteniendo un Negocio: {idNegocio}");
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar el negocio {ex.Message}", ex.ToString());
                throw new NegocioExceptions("Negocio no existe");
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return negociomodel;

        }

        public List<NegocioModel> GetAllNegocio()
        {
            List<NegocioModel> negocio = new List<NegocioModel>();
            try
            {
                this.logger.LogInformation("Obteniendo Negocios...");
                negocio = this.context.Negocio
                    .Where(ne => !ne.Deleted)
                    .Select(neg => new NegocioModel()
                    {
                        idNegocio = neg.idNegocio,
                        urlLogo = neg.urlLogo,
                        nombreLogo = neg.nombreLogo,
                        numeroDocumento = neg.numeroDocumento,
                        nombre = neg.nombre,
                        correo = neg.correo,
                        direccion = neg.direccion,
                        porcentajeImpuesto = neg.porcentajeImpuesto,
                        simboloMoneda = neg.simboloMoneda
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocios {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return negocio;
        }
    }
}

