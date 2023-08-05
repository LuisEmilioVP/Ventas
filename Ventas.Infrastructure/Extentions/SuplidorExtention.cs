using System;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class SuplidorExtention
    {
        public static SuplidorModels ConvertSuplidorEntityToModel(this Suplidor suplidor)
        {
            SuplidorModels suplidorModels = new SuplidorModels()
            {

                IdSuplidor = suplidor.IdSuplidor,
                Nombre = suplidor.Nombre,
                Contacto = suplidor.Contacto,
                Direccion = suplidor.Direccion,
                Ciudad = suplidor.Ciudad,
                Region = suplidor.Region,
                Codigo_postal = suplidor.Codigo_postal,
                Pais = suplidor.Pais,
                Telefono = suplidor.Telefono,
                Fax = suplidor.Fax
                
                
            };
            return suplidorModels;
        }

        public static Suplidor ConvertSuplidorCreateToEntity(this Suplidor suplidor)
        {
            return new Suplidor()
            {
                Nombre = suplidor.Nombre,
                Contacto = suplidor.Contacto,
                Direccion = suplidor.Direccion,
                Ciudad = suplidor.Ciudad,
                Region = suplidor.Region,
                Codigo_postal = suplidor.Codigo_postal,
                Pais = suplidor.Pais,
                Telefono = suplidor.Telefono,
                Fax = suplidor.Fax,
                CreationUser = suplidor.CreationUser,
                CreationDate = suplidor.CreationDate
            };
        }

        public static Suplidor ConvertSuplidorUpdateToEntity(this Suplidor suplidorToUpdate, Suplidor suplidor)
        {
            suplidorToUpdate.IdSuplidor = suplidor.IdSuplidor;
            suplidorToUpdate.Nombre = suplidor.Nombre;
            suplidorToUpdate.Contacto = suplidor.Contacto;
            suplidorToUpdate.Direccion = suplidor.Direccion;
            suplidorToUpdate.Ciudad = suplidor.Ciudad;
            suplidorToUpdate.Region = suplidor.Region;
            suplidorToUpdate.Codigo_postal = suplidor.Codigo_postal;
            suplidorToUpdate.Pais = suplidor.Pais;
            suplidorToUpdate.Telefono = suplidor.Telefono;
            suplidorToUpdate.Fax = suplidor.Fax;
            suplidorToUpdate.UserMod = suplidor.UserMod;
            suplidorToUpdate.ModifyDate = suplidor.ModifyDate;

            return suplidorToUpdate;
        }

        public static Suplidor ConvertSuplidorDeletedToEntity(this Suplidor suplidorToDeleted, Suplidor suplidor)
        {

            suplidorToDeleted.Deleted = true;
            suplidorToDeleted.UserDeleted = suplidor.UserDeleted;
            suplidorToDeleted.DeletedDate = suplidor.DeletedDate = DateTime.Now;

            return suplidorToDeleted;

        }

    }
}
