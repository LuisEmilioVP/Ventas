using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;

namespace Ventas.Infrastructure.Repositories
{
    public class CategoriasRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ILogger<CategoriasRepository> logger;
        private readonly VentasContext context;

        public CategoriasRepository(ILogger<CategoriasRepository> logger,
            VentasContext ventas) : base(ventas)
        {
            this.logger = logger;
            this.context = ventas;
        }

        public List<Categoria> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetCategoria(int idCategory)
        {
            throw new NotImplementedException();
        }
    }
}
