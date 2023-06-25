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


        public List<SuplidorModels> GetAllSuplidor()
        {
            List<SuplidorModels> suplidor = new List<SuplidorModels>();

            try
            {
                suplidor = this.context.Suplidor.Where(sup => sup.Deleted).Select(su => new SuplidorModels()
                {
                    Nombre = su.Nombre,
                    Contacto = su.Contacto,
                    Direccion = su.Direccion,
                    Ciudad = su.Ciudad,
                    Region = su.Region,
                    Codigo_postal = su.Codigo_postal,
                    Pais = su.Pais,
                    Telefono = su.Telefono,
                    Fax = su.Fax
                }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Se produjo un error durante el proceso de carga del suplidor", ex.ToString());
            }
            return suplidor;
        }

        public SuplidorModels GetsuplidorById(int id)
        {
            SuplidorModels suplidorModels = new SuplidorModels();

            try
            {
                if (!base.Exists(sup => sup.IdSuplidor == id))
                    throw new SuplidorNotFoundException("Suplidor no encontrado");

                suplidorModels = base.GetEntity(id).ConvertSuplidorEntityToModel();
                this.logger.LogInformation($"Obteniendo un Suplidor: {id}");
            }
            catch (Exception ex)
            {
                this.logger.LogError("Se produjo un error durante el proceso de carga del suplidor", ex.ToString());
                throw new SuplidorException("Suplidor no existente");
                throw new ConnectionException($"Error al conectarse con la Base de datos: {ex.Message}");
            }

            return suplidorModels;
        }


        public override void Add(Suplidor entity)
        {
            try
            {
                if (this.Exists(sup => sup.Nombre == entity.Nombre))
                {
                    throw new SuplidorException("Suplidor existente");
                }
                base.Add(entity);
                base.SaveChanges();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante la agregacion del suplidor");
            }
        }

        public override void Update(Suplidor entity)
        {
            try
            {
                Suplidor suplidorUpdate = this.GetEntity(entity.IdSuplidor);

                suplidorUpdate.IdSuplidor = entity.IdSuplidor;
                suplidorUpdate.Nombre = entity.Nombre;
                suplidorUpdate.Contacto = entity.Contacto;
                suplidorUpdate.Direccion = entity.Direccion;
                suplidorUpdate.Ciudad = entity.Ciudad;
                suplidorUpdate.Region = entity.Region;
                suplidorUpdate.Codigo_postal = entity.Codigo_postal;
                suplidorUpdate.Pais = entity.Pais;
                suplidorUpdate.Telefono = entity.Telefono;
                suplidorUpdate.Fax = entity.Fax;

                suplidorUpdate.UserMod = entity.UserMod;
                suplidorUpdate.ModifyDate = entity.ModifyDate;

                this.context.Suplidor.Update(suplidorUpdate);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante la actualización del suplidor", ex.ToString());
            }
        }

        public override void Remove(Suplidor entity)
        {
            try
            {
                Suplidor suplidorRemove = this.GetEntity(entity.IdSuplidor);

                suplidorRemove.UserDeleted = entity.UserDeleted;
                suplidorRemove.DeletedDate = entity.DeletedDate;
                suplidorRemove.Deleted = entity.Deleted;

                this.context.Suplidor.Update(suplidorRemove);
                this.context.SaveChanges();

            }
            catch(Exception ex)
            {
                this.logger.LogError("Se produjo un fallo durante el eliminado del suplidor");
            }
        }

           }
}
