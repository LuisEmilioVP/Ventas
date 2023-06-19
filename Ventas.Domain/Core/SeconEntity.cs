using System;


namespace Ventas.Domain.Core
{
    public abstract class SeconEntity : BaseEntity
    {
        public SeconEntity()
        {
            this.FechaRegistro = DateTime.Now;
            this.EsActivo = true;
        }
        public DateTime? FechaRegistro { get; set; }
        public bool? EsActivo { get; set; }


    }

}

