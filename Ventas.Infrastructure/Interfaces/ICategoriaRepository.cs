using System;
using System.Collections.Generic;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;

namespace Ventas.Infrastructure.Interfaces
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        List<Categoria> GetAllCategory();

        List<Categoria> GetCategoria(int idCategory);
    }
}