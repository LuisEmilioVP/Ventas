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

        public List<NegocioModel> GetAllNegocio()
        {
            List<NegocioModel> NegocioList = new List<NegocioModel>();
            try
            {
                this.logger.LogInformation($"Obteniendo Negocios");
                NegocioList = (from use in base.GetEntities()
                               select new NegocioModel()
                               {
                                   urlLogo = use.urlLogo,
                                   nombreLogo = use.nombreLogo,
                                   numeroDocumento = use.numeroDocumento,
                                   nombre = use.nombre,
                                   correo = use.correo,
                                   direccion = use.direccion,
                                   porcentajeImpuesto = use.porcentajeImpuesto,
                                   simboloMoneda = use.simboloMoneda
                               }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocio {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return NegocioList;
        }

        public NegocioModel GetNegocio(int id)
        {
            NegocioModel NegocioModel = new NegocioModel();
            try
            {
                this.logger.LogInformation($"Obteniendo un Usuario: {id}");
                Negocio negocio = this.GetEntity(id);

                NegocioModel.urlLogo = negocio.urlLogo;
                NegocioModel.nombreLogo = negocio.nombreLogo;
                NegocioModel.numeroDocumento = negocio.numeroDocumento;
                NegocioModel.nombre = negocio.nombre;
                NegocioModel.correo = negocio.correo;
                NegocioModel.direccion = negocio.direccion;
                NegocioModel.porcentajeImpuesto = negocio.porcentajeImpuesto;
                NegocioModel.simboloMoneda = negocio.simboloMoneda;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocio {ex.Message}", ex.ToString());
            }

            return NegocioModel;
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
                negocioToUpdate.UserMod = entity.UserMod;
                negocioToUpdate.ModifyDate = entity.ModifyDate;


                this.context.Negocio.Update(negocioToUpdate);
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

    }
}

