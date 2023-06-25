﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ventas.Domain.Entities;

namespace Ventas.Infrastructure.Context
{
    public class VentasContext : DbContext
    {
      

        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options) 
            : base(options)
        {
        }

        public DbSet<Venta>? Ventas { get; set; }
        public IEnumerable<object> Venta { get; internal set; }
    }
}
