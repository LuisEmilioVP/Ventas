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
using static Ventas.Infrastructure.Exceptions.SuplidorException;

namespace Ventas.Infrastructure.Repositories
{
    public class SuplidorRepository : BaseRepository<Suplidor>, ISuplidorRepository
    {
        private readonly ILogger<SuplidorRepository> logger;
        private readonly VentasContext context;

        public SuplidorRepository(ILogger<SuplidorRepository> logger,
            VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        public override void Add(Suplidor entity)
        {
            this.logger.LogInformation("Se va agregar un nuevo suplidor");

            try
            {
                if (entity == null)
                    throw new SuplidorException("Un Suplidor no puede ser nulo");

              
                entity.ConvertSuplidorCreateToEntity();

                base.Add(entity);
                this.logger.LogInformation($"Un nuevo suplidor insertado: {entity.Nombre}");
                base.SaveChanges();
            }
            catch (SuplidorException ex)
            {
                this.logger.LogError($"Algo ha fallado: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el Suplidor {ex.Message}", ex.ToString());
                throw new ConnectionException($"Error de Conexión con la base de datos: {ex.Message}");
            }
        }

        public SuplidorModels GetsuplidorById(int idsuplidor)
        {
            SuplidorModels suplidorModels = new SuplidorModels();

            try
            {
                this.logger.LogInformation($"Obteniendo Suplidor de id: {idsuplidor}");

                Suplidor suplidor = context.Suplidor.FirstOrDefault(supl => supl.IdSuplidor == idsuplidor);

                if (suplidor == null)
                    throw new SuplidorNotFoundException(
                        $"El suplidor de id: {idsuplidor} no encontrado en la base de datos");

                suplidorModels = suplidor.ConvertSuplidorEntityToModel();
                this.logger.LogInformation($"Obteniendo el suplidor de Id: {idsuplidor}");
            }
            catch (SuplidorException ex)
            {
                this.logger.LogError($"Algo ha fallado: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar suplidor {ex.Message}", ex.ToString());
                throw new ConnectionException($"Error de Conexión con la base de datos: {ex.Message}");
            }

            return suplidorModels;
        }
    

        public override void Update(Suplidor entity)
        {
            try
            {
                this.logger.LogInformation($"Se actualizará el suplidor con el id: {entity.IdSuplidor}");

                Suplidor suplidorToUpdate = base.GetEntity(entity.IdSuplidor)  ?? throw new SuplidorNotFoundException(
                        "Suplidor no encontrado en la base de datos");


                if (suplidorToUpdate.Deleted == true)
                    throw new SuplidorException("El Suplidor a actualizar ya está eliminado");


                suplidorToUpdate.ConvertSuplidorUpdateToEntity(entity);

                base.Update(suplidorToUpdate);
                this.logger.LogInformation($"El suplidor de id: {entity.IdSuplidor} ha sido actualizado");
                this.SaveChanges();
            }
            catch (SuplidorException ex)
            {
                this.logger.LogError($"Algo ha fallado: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar el suplidor: {ex.Message}", ex.ToString());
                throw new ConnectionException($"Error de Conexión con la base de datos: {ex.Message}");
            }
        }

        public override void Remove(Suplidor entity)
        {
            try
            {
                this.logger.LogInformation($"Se eliminará el suplidor con el id: {entity.IdSuplidor}");

                Suplidor suplidorToRemove = this.GetEntity(entity.IdSuplidor)
                 ?? throw new SuplidorNotFoundException(
                     "El suplidor no encontrado en la base de datos");


                suplidorToRemove.ConvertSuplidorDeletedToEntity(entity);

                this.context.Update(suplidorToRemove);
                this.logger.LogInformation($"El suplidor del id: {entity.IdSuplidor} ha sido eliminado");
                this.context.SaveChanges();
            }
            catch (SuplidorException ex)
            {
                this.logger.LogError($"Algo ha fallado: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al eliminar  suplidor: {ex.Message}", ex.ToString());
                throw new ConnectionException($"Error de Conexión con la base de datos: {ex.Message}");
            }
        }

        List<SuplidorModels> ISuplidorRepository.GetAllSuplidor()
        {
            List<SuplidorModels> suplidores = new List<SuplidorModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Suplidor");

                List<Suplidor> suplidor = base.GetEntities()
                      .Where(cat => !cat.Deleted).ToList();

                if (suplidor == null)
                    throw new SuplidorNotFoundException("El suplidor no ha sido encontrado en la base de datos");

                foreach (Suplidor supli in suplidor)
                {
                    SuplidorModels suplidorModels = supli.ConvertSuplidorEntityToModel();
                    suplidores.Add(suplidorModels);
                }
            }
            catch (SuplidorException ex)
            {
                this.logger.LogError($"Algo ha fallado: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar suplidores{ex.Message}", ex.ToString());
                throw new ConnectionException($"Error de Conexión con la base de datos: {ex.Message}");
            }

            return suplidores;
        }
    }
}
