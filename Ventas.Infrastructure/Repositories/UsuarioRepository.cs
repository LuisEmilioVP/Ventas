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
using Ventas.Infrastructure.Extentions;

namespace Ventas.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> logger;
        private readonly VentasContext context;

        public UsuarioRepository(ILogger<UsuarioRepository> logger,
            VentasContext ventas) : base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

        public override void Add(Usuario entity)
        {
            try
            {
                if (this.Exists(us => us.Nombre == entity.Nombre))
                    throw new UsuarioExceptions("¡El usuario ya existe!");

                base.Add(entity);
                base.SaveChanges();
                this.logger.LogInformation($"Nuevo usuario insertado: {entity.Nombre}");
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Error al agregar usuario: {ex.Message}", ex.ToString());
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al agregar usuario: {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Update(Usuario entity)
        {
            try
            {
                Usuario usuarioToUpdate = this.GetEntity(entity.IdUsuario)
                    ?? throw new UsuarioNotFoundException(
                        "Usuario no encontrado en la base de datos");

                usuarioToUpdate.IdUsuario = entity.IdUsuario;
                usuarioToUpdate.Nombre = entity.Nombre;
                usuarioToUpdate.Correo = entity.Correo;
                usuarioToUpdate.UrlFoto = entity.UrlFoto;
                usuarioToUpdate.NombreFoto = entity.NombreFoto;
                usuarioToUpdate.Clave = entity.Clave;
                usuarioToUpdate.EsActivo = entity.EsActivo;
                usuarioToUpdate.FechaRegistro = entity.FechaRegistro;
                usuarioToUpdate.UserMod = entity.UserMod;
                usuarioToUpdate.ModifyDate = entity.ModifyDate;

                this.context.Usuario.Update(usuarioToUpdate);
                this.context.SaveChanges();
                this.logger.LogInformation("Actualización de usuario exitosa.");
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Error al actualizar usuario: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al actualizar usuario: {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public override void Remove(Usuario entity)
        {
            try
            {
                Usuario usuarioToRemove = this.GetEntity(entity.IdUsuario)
                      ?? throw new UsuarioNotFoundException(
                          "Usuario no encontrado en la base de datos");

                usuarioToRemove.Deleted = entity.Deleted;
                usuarioToRemove.UserDeleted = entity.UserDeleted;
                usuarioToRemove.DeletedDate = entity.DeletedDate;

                this.context.Update(usuarioToRemove);
                this.context.SaveChanges();
                this.logger.LogInformation("Eliminación de usuario exitosa.");
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Error al eliminar usuario: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al eliminar usuario: {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }

        public List<UsuarioModels> GetAllUser()
        {
            List<UsuarioModels> usuarios = new List<UsuarioModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Usuarios...");
                usuarios = this.context.Usuario
                    .Where(us => !us.Deleted)
                    .Select(use => new UsuarioModels()
                    {
                        Nombre = use.Nombre,
                        Correo = use.Correo,
                        Telefono = use.Telefono,
                        UrlFoto = use.UrlFoto,
                        NombreFoto = use.NombreFoto,
                        EsActivo = use.EsActivo,
                        FechaRegistro = use.FechaRegistro,
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Usuarios {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return usuarios;
        }

        public UsuarioModels GetUserById(int userId)
        {
            UsuarioModels usuarioModels = new UsuarioModels();

            try
            {
                if (!base.Exists(use => use.IdUsuario == userId))
                    throw new UsuarioNotFoundException(
                        "Usuario no encontrado en la base de datos");

                usuarioModels = base.GetEntity(userId).ConvertUserEntityToModel();
                this.logger.LogInformation($"Obteniendo un Usuario: {userId}");
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar el usuario {ex.Message}", ex.ToString());
                throw new UsuarioExceptions("Usuario no existe...");
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return usuarioModels;
        }
    }
}

