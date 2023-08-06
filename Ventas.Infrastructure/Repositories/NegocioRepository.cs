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
            this.logger.LogInformation("Se agregará un nuevo negocio…");

            try
            {
                if (entity == null)
                    throw new NegocioExceptions("Un Negocio no puede ser nulo");

                // Capturar nombre de usuario y correo para evitar que se repitan
                string? name = entity.nombre;
                string? email = entity.correo;

                if (this.Exists(us => us.correo == entity.correo))
                    throw new NegocioExceptions($"¡El correo: {email} ya existe!");

                entity.ConvertNegocioCreateToEntity();

                base.Add(entity);
                this.logger.LogInformation($"Agregando el usuario: {name} con el correo: {email}");
                base.SaveChanges();
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al agregar usuario: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Update(Negocio entity)
        {
            try
            {
                this.logger.LogInformation($"Se actualizará el Negocio con el, Id: {entity.idNegocio}");

                Negocio negocioToUpdate = base.GetEntity(entity.idNegocio)
                    ?? throw new NegocioNotFoundException(
                        "Negocio no encontrado en la base de datos");

                if (negocioToUpdate.Deleted == true)
                    throw new NegocioExceptions("El Negocio a actualizar está eliminado");

                negocioToUpdate.ConvertNegocioUpdateToEntity(entity);

                base.Update(negocioToUpdate);
                this.logger.LogInformation($"El Negocio de id: {entity.idNegocio} ha sido actualizado");
                this.context.SaveChanges();
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar Negocio: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Remove(Negocio entity)
        {
            try
            {
                this.logger.LogInformation($"Se eliminará el usuario con el Id: {entity.idNegocio}");

                Negocio negocioToRemove = base.GetEntity(entity.idNegocio)
                      ?? throw new NegocioNotFoundException(
                          "Negocio no encontrado en la base de datos");

                if (negocioToRemove.Deleted == true)
                    throw new NegocioExceptions("El usuario ya ha sido eliminado");

                negocioToRemove.ConvertNegocioRemoveToEntity(entity);

                this.context.Update(negocioToRemove);
                this.logger.LogInformation($"El Negocio de Id: {entity.idNegocio} ha sido eliminado");
                this.context.SaveChanges();
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al eliminar usuario: {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public NegocioModel GetNegocio(int NegocioId)
        {
            NegocioModel negociomodel = new NegocioModel();

            try
            {
                this.logger.LogInformation($"Obteniendo Usuario de Id: {NegocioId}");

                Negocio nego = context.Negocio.FirstOrDefault(use => use.idNegocio == NegocioId);

                if (nego == null)
                    throw new NegocioNotFoundException(
                            $"Negocio de id: {NegocioId} no encontrado en la base de datos");

                negociomodel = nego.ConvertUserEntityToModel();

                this.logger.LogInformation($"Obteniendo al usuario de Id: {NegocioId}");
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el usuario {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return negociomodel;
        }
        public List<NegocioModel> GetAllNegocio()
        {
            List<NegocioModel> negocios = new List<NegocioModel>();
            try
            {
                this.logger.LogInformation("Obteniendo Negocio...");

                List<Negocio> negos = base.GetEntities()
                    .Where(use => !use.Deleted == true)
                    .ToList();

                if (negos == null)
                    throw new NegocioNotFoundException(
                        "Negocio no encontrado en la base de datos");

                foreach (Negocio negocio in negos)
                {
                    NegocioModel negocioModel = negocio.ConvertUserEntityToModel();
                    negocios.Add(negocioModel);
                }
            }
            catch (NegocioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Usuarios {ex.Message}", ex.ToString());
                throw new NDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return negocios;
        }
    }
}

