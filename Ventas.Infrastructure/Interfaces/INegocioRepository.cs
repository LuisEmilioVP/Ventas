using System.Collections.Generic;
using Ventas.Domain.Repository;

namespace Ventas.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        List<NegocioModels> GetAllUser();

        List<NegocioModels> GetUser(int idUser);
    }
}