using System;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extensions
{
    public static class NegocioExtention
    {
        public static NegocioModel ConvertUserEntityToModel(this Negocio negocio)
        {
            NegocioModel negocioModel = new NegocioModel()
            {
                idNegocio = negocio.idNegocio,
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                telefono = negocio.telefono,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda
            };
                
            return negocioModel;
        }

        public static Negocio ConvertNegocioCreateToEntity(this Negocio negocio)
        {
            return new Negocio()
            {
                urlLogo = negocio.urlLogo,
                nombreLogo = negocio.nombreLogo,
                numeroDocumento = negocio.numeroDocumento,
                nombre = negocio.nombre,
                correo = negocio.correo,
                direccion = negocio.direccion,
                telefono = negocio.telefono,
                porcentajeImpuesto = negocio.porcentajeImpuesto,
                simboloMoneda = negocio.simboloMoneda,
                CreationUser = negocio.CreationUser,
                CreationDate = negocio.CreationDate = DateTime.Now,
            };
        }

        public static Negocio ConvertNegocioUpdateToEntity(this Negocio negocioToUpdate,
                                                            Negocio negocio)
        {
            negocioToUpdate.urlLogo = negocio.urlLogo;
            negocioToUpdate.nombreLogo = negocio.nombreLogo;
            negocioToUpdate.numeroDocumento = negocio.numeroDocumento;
            negocioToUpdate.nombre = negocio.nombre;
            negocioToUpdate.correo = negocio.correo;
            negocioToUpdate.direccion = negocio.direccion;
            negocioToUpdate.telefono = negocio.telefono;
            negocioToUpdate.porcentajeImpuesto = negocio.porcentajeImpuesto;
            negocioToUpdate.simboloMoneda = negocio.simboloMoneda;
            negocioToUpdate.UserMod = negocio.UserMod;
            negocioToUpdate.ModifyDate = negocio.ModifyDate = DateTime.Now;

            return negocioToUpdate;
        }

        public static Negocio ConvertNegocioRemoveToEntity(this Negocio negocioToRemove,
                                                           Negocio negocio)
        {
            negocioToRemove.Deleted = true;
            negocioToRemove.UserDeleted = negocio.UserDeleted;
            negocioToRemove.DeletedDate = negocio.DeletedDate = DateTime.Now;

            return negocioToRemove;
        }
    }
}

    

