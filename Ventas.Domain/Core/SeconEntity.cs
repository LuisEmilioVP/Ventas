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

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public string? Descripcion { get; set; }

        public bool? EsActivo { get; set; }


}

}



