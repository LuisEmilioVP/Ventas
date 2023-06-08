using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Entities;
using Ventas.Domain.Repository;
using Ventas.Infrastructure.Core;
using Ventas.Infrastructure.Models;

namespace Ventas.Infrastructure.Interfaces
{
    public  interface ISuplidorRepository : IBaseRepository<Suplidor>
    {

        List<SuplidorModels> GetAllSuplidor();
        List<SuplidorModels> Getsuplidor(int idSuplidor);

    }
}
