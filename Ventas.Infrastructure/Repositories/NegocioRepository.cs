using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Ventas.Domain.Entities;
using Ventas.Infrastructure.Context;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Interfaces;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Repositories
{
    public class NegocioRepository : BaseRepository<NegocioModel>, INegocioRepository
    {
        private readonly ILogger<NegocioRepository> logger;
        private readonly VentasContext context;

        public NegocioRepository(ILogger<NegocioRepository> logger,
           VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public bool Exists(System.Linq.Expressions.Expression<Func<Negocio, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<NegocioModel> GetAllNegocio()
        {
            List<NegocioModel> NegocioList = new List<NegocioModel>();
            try
            {
                this.logger.LogInformation($"Obteniendo Negocios");
                NegocioList = (from use in base.GetEntities()
                               select new NegocioModel()
                               {
                                   urlLogo = use.urlLogo,
                                   nombreLogo = use.nombreLogo,
                                   numeroDocumento = use.numeroDocumento,
                                   nombre = use.nombre,
                                   correo = use.correo,
                                   direccion = use.direccion,
                                   porcentajeImpuesto = use.porcentajeImpuesto,
                                   simboloMoneda = use.simboloMoneda
                               }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocio {ex.Message}", ex.ToString());
            }

            return NegocioList;
        }

        public NegocioModel GetNegocio(int idNegocio)
        {
            NegocioModel Negocio = new NegocioModel();
            try
            {
                this.logger.LogInformation($"Obteniendo un Negocio: {idNegocio}");
                Negocio = (from use in base.GetEntities()
                           where use.idNegocio == idNegocio
                           select new NegocioModel()
                           {
                               urlLogo = use.urlLogo,
                               nombreLogo = use.nombreLogo,
                               numeroDocumento = use.numeroDocumento,
                               nombre = use.nombre,
                               correo = use.correo,
                               direccion = use.direccion,
                               porcentajeImpuesto = use.porcentajeImpuesto,
                               simboloMoneda = use.simboloMoneda
                           }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocio {ex.Message}", ex.ToString());
            }

            return Negocio;
        }

        public NegocioModel GetUniqueNegocio()
        {
            NegocioModel Negocio = new NegocioModel();
            try
            {
                this.logger.LogInformation($"Obteniendo  Negocio");
                Negocio = (from use in base.GetEntities()
                           select new NegocioModel()
                           {
                               urlLogo = use.urlLogo,
                               nombreLogo = use.nombreLogo,
                               numeroDocumento = use.numeroDocumento,
                               nombre = use.nombre,
                               correo = use.correo,
                               direccion = use.direccion,
                               porcentajeImpuesto = use.porcentajeImpuesto,
                               simboloMoneda = use.simboloMoneda
                           }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error al cargar Negocio {ex.Message}", ex.ToString());
            }

            return Negocio;
        }


    }

}