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
    public class SuplidorRepository : BaseRepository<Suplidor>, ISuplidorRepository
    {
        private readonly ILogger<SuplidorRepository> logger;
        private readonly VentasContext context;

        public SuplidorRepository(ILogger<SuplidorRepository> logger, 
            VentasContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<SuplidorModels> GetAllSuplidor()
        {
            throw new NotImplementedException();
        }

        public List<SuplidorModels> Getsuplidor(int idSuplidor)
        {
            List<SuplidorModels> suplidor = new List<SuplidorModels>();
            try
            {
                this.logger.LogInformation($"He pasado: {idSuplidor}");
   
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error con el suplidor:{ex.Message}", ex.ToString());
            }

        }
    }
}
