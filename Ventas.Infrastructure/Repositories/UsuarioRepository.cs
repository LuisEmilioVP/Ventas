using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ILogger<UsuarioRepository> logger;
        private readonly VentasContext context;

        public UsuarioRepository(ILogger<UsuarioRepository> logger, 
            VentasContext context):base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<UsuarioModels> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public List<UsuarioModels> GetUser(int idUser)
        {
            try
            {
                this.logger.LogInformation($"Obteniendo un Usuario: {idUser}");
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al Cargar Usuario {ex.Message}", ex.ToString());
            }
        }
    }
}
