using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        List<UsuarioModels> GetAllUser();

        List<UsuarioModels> GetUser(int idUser);
    }
}
