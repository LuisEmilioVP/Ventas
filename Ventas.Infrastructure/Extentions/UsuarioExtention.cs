using System;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Extentions
{
    public static class UsuarioExtention
    {
        public static UsuarioModels ConvertUserEntityToModel(this Usuario usuario)
        {
            UsuarioModels userModel = new UsuarioModels()
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                UrlFoto = usuario.UrlFoto,
                NombreFoto = usuario.NombreFoto,
                EsActivo = usuario.EsActivo,
                FechaRegistro = usuario.FechaRegistro
            };

            return userModel;
        }

        public static Usuario ConvertUsuarioCreateToEntity(this Usuario usuario)
        {
            return new Usuario()
            {
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                UrlFoto = usuario.UrlFoto,
                Clave = usuario.Clave,
                NombreFoto = usuario.NombreFoto,
                EsActivo = usuario.EsActivo = true,
                FechaRegistro = usuario.FechaRegistro = DateTime.Now,
                CreationUser = usuario.CreationUser,
                CreationDate = usuario.CreationDate = DateTime.Now,
            };
        }

        public static Usuario ConvertUsuarioUpdateToEntity (this Usuario usuarioToUpdate, 
                                                            Usuario usuario)
        {
            usuarioToUpdate.IdUsuario = usuario.IdUsuario;
            usuarioToUpdate.Nombre = usuario.Nombre;
            usuarioToUpdate.Correo = usuario.Correo;
            usuarioToUpdate.UrlFoto = usuario.UrlFoto;
            usuarioToUpdate.NombreFoto = usuario.NombreFoto;
            usuarioToUpdate.Clave = usuario.Clave;
            usuarioToUpdate.EsActivo = usuario.EsActivo = true;
            usuarioToUpdate.FechaRegistro = usuario.FechaRegistro = DateTime.Now;
            usuarioToUpdate.UserMod = usuario.UserMod;
            usuarioToUpdate.ModifyDate = usuario.ModifyDate = DateTime.Now;

            return usuarioToUpdate;
        }

        public static Usuario ConvertUsuarioRemoveToEntity(this Usuario usuarioToRemove, 
                                                           Usuario usuario) 
        {
            usuarioToRemove.EsActivo = false;
            usuarioToRemove.Deleted = usuario.Deleted;
            usuarioToRemove.UserDeleted = usuario.UserDeleted;
            usuarioToRemove.DeletedDate = usuario.DeletedDate = DateTime.Now;

            return usuarioToRemove;
        }
    }
}
