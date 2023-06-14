using System.Collections.Generic;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface INegocioRepository : IBaseRepository<NegocioModel>
    {
        List<NegocioModel> GetAllNegocio();

        NegocioModel GetNegocio(int idNegocio);
    }
}