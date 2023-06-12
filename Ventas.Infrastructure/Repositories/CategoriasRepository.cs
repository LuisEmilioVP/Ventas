using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

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

        public List<CategoriaModels> GetAllCategory()
        {
            List<CategoriaModels> categorias = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation("Obteniendo Categorias...");
                categorias = (from ca in base.GetEntities()
                              select new CategoriaModels()
                              {
                                  IdCategoria = ca.IdCategoria,
                                  Descripcion = ca.Descripcion,
                                  EsActivo = ca.EsActivo,
                                  FechaRegistro = ca.FechaRegistro
                              }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al Cargar Categorias: {ex.Message}", ex.ToString());
            }

            return categorias;
        }

        public List<CategoriaModels> GetCategoria(int IdCategoria)
        {
            List<CategoriaModels> categoria = new List<CategoriaModels>();
            try
            {
                this.logger.LogInformation($"Obteniendo una Categoria: {IdCategoria}");
                categoria = (from ca in base.GetEntities()
                             where ca.IdCategoria == IdCategoria
                             select new CategoriaModels()
                             {
                                 IdCategoria = ca.IdCategoria,
                                 Descripcion = ca.Descripcion,
                                 EsActivo = ca.EsActivo,
                                 FechaRegistro = ca.FechaRegistro
                             }).ToList();
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error al cargar Categoria: {ex.Message}", ex.ToString());
            }

            return categoria;
        }
    }
}
