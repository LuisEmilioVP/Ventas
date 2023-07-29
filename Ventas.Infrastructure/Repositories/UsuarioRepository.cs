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
            this.logger.LogInformation("Se agregará un nuevo usuario…");
            try
            {
                if (entity == null)
                    throw new UsuarioExceptions("Un usuario no puede ser nulo");

                // Capturar nombre de usuario y correo para evitar que se repitan
                string? name = entity.Nombre;
                string? email = entity.Correo;

                if (this.Exists(us => us.Correo == entity.Correo && entity.EsActivo == true))
                    throw new UsuarioExceptions($"¡El correo: {email} ya existe!");

                entity.ConvertUsuarioCreateToEntity();

                base.Add(entity);
                this.logger.LogInformation($"Agregando el usuario: {name} con el correo: {email}");
                base.SaveChanges();
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
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
                this.logger.LogInformation($"Se actualizará el usuario con el, Id: {entity.IdUsuario}");

                Usuario usuarioToUpdate = base.GetEntity(entity.IdUsuario)
                    ?? throw new UsuarioNotFoundException(
                        "Usuario no encontrado en la base de datos");

                if (usuarioToUpdate.EsActivo == false && usuarioToUpdate.Deleted == false)
                    throw new UsuarioExceptions("El usuario a actualizar está eliminado");

                usuarioToUpdate.ConvertUsuarioUpdateToEntity(entity);

                base.Update(usuarioToUpdate);
                this.logger.LogInformation($"El usuario de Id: {entity.IdUsuario} ha sido actualizado");
                this.context.SaveChanges();
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
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
                this.logger.LogInformation($"Se eliminará el usuario con el, Id: {entity.IdUsuario}");

                Usuario usuarioToRemove = base.GetEntity(entity.IdUsuario)
                      ?? throw new UsuarioNotFoundException(
                          "Usuario no encontrado en la base de datos");

                if (usuarioToRemove.EsActivo == false)
                    throw new UsuarioExceptions("El usuario ya ha sido eliminado");

                usuarioToRemove.ConvertUsuarioRemoveToEntity(entity);

                this.context.Update(usuarioToRemove);
                this.logger.LogInformation($"El usuario de Id: {entity.IdUsuario} ha sido eliminado");
                this.context.SaveChanges();
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
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

                List<Usuario> users = base.GetEntities()
                    .Where(use => !use.Deleted && use.EsActivo == true).ToList()
                    ?? throw new UsuarioNotFoundException(
                        "Usuario no encontrado en la base de datos");

                foreach (Usuario usuario in users)
                {
                    UsuarioModels usuarioModels = usuario.ConvertUserEntityToModel();
                    usuarios.Add(usuarioModels);
                }
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
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
                this.logger.LogInformation($"Obteniendo Usuario de Id: {userId}");

                Usuario user = context.Usuario.FirstOrDefault(uid => uid.IdUsuario == userId 
                && uid.EsActivo == true)
                    ?? throw new UsuarioNotFoundException(
                        $"Usuario de id: {userId} no encontrado en la base de datos");

                usuarioModels = user.ConvertUserEntityToModel();
                this.logger.LogInformation($"Obteniendo al usuario de Id: {userId}");
            }
            catch (UsuarioExceptions ex)
            {
                this.logger.LogError($"Algo salió mal: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar el usuario {ex.Message}", ex.ToString());
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

            return usuarioModels;
        }
    }
}

