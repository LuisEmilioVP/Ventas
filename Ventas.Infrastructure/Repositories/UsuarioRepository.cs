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
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> logger;
        private readonly VentasContext context;

        public UsuarioRepository(ILogger<UsuarioRepository> logger, 
            VentasContext ventas):base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

        public List<UsuarioModels> GetAllUser()
        {
            List<UsuarioModels> usuarios = new List<UsuarioModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Usuarios...");
                usuarios = (from use in base.GetEntities()
                            select new UsuarioModels()
                            {
                                IdUsuario = use.IdUsuario,
                                Nombre = use.Nombre,
                                Correo = use.Correo,
                                Telefono = use.Telefono,
                                UrlFoto = use.UrlFoto,
                                NombreFoto = use.NombreFoto,
                                Clave = use.Clave,
                                EstaActivo = use.EsActivo
                            }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Usuarios {ex.Message}", ex.ToString());
            }

            return usuarios;
        }

        public List<UsuarioModels> GetUser(int idUser)
        {
            List<UsuarioModels> usuario = new List<UsuarioModels> ();
            try
            {
                this.logger.LogInformation($"Obteniendo un Usuario: {idUser}");
                usuario = (from use in base.GetEntities()
                           where use.IdUsuario == idUser
                           select new UsuarioModels()
                           {
                               IdUsuario = use.IdUsuario,
                               Nombre = use.Nombre,
                               Correo = use.Correo,
                               Telefono = use.Telefono,
                               UrlFoto = use.UrlFoto,
                               NombreFoto = use.NombreFoto,
                               Clave = use.Clave,
                               EstaActivo = use.EsActivo
                           }).ToList();
            }
            catch (Exception ex) 
            {
                this.logger.LogError($"Error al cargar Usuario {ex.Message}", ex.ToString());
            }

            return usuario;
        }

        public override void Add(Usuario entity)
        {
            try
            {
                if (this.Exists(us => us.Nombre == entity.Nombre))
                {
                    throw new UsuarioExceptions("¡El usuario ya existe!");
                }

                base.SaveChanges();
            } 
            catch(Exception ex) 
            {
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }

        }

        public override void Update(Usuario entity)
        {
            try
            {
                if (this.Exists(us => us.IdUsuario != entity.IdUsuario))
                {
                    throw new UsuarioExceptions("Usuario no encontrado en la base de datos");
                }


                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UDatabaseConnectionException($"Error de conexión: {ex.Message}");
            }
        }
    }
}
