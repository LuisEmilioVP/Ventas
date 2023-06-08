using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository

    {

        private readonly ILogger<ProductoRepository> logger;
        private readonly VentasContext context;

        public ProductoRepository(ILogger<ProductoRepository> logger, VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<ProductoModels> GetProducto()
        {
            throw new NotImplementedException();
        }

        public List<ProductoModels> GetProducto(int idproducto)
        {
            throw new NotImplementedException();
        }
    }
}


