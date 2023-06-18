using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public interface INegocioRepository : IBaseRepository<Negocio>
    {
        List<NegocioModel> GetAllNegocio();

        NegocioModel GetNegocio(int idNegocio);
    }
}