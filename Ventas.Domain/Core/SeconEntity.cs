using System;

namespace Ventas.Domain.Core
{
    public class SeconEntity : BaseEntity
    {
        public SeconEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.EsActivo = false;
        }

        public DateTime? FechaRegistro { get; set;}
        public bool? EsActivo { get; set; }
    }
}
