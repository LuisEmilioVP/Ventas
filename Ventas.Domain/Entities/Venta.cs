using System;
using System.Reflection;

namespace Ventas.Domain.Entities
{
    public class Venta
    {
        
       public int IdVenta { get; set; }
        public string? NumeroVenta { get; set; }
        public int IdTipoDocumentoVenta { get; set; }
        public int IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime  FechaRegistro { get; set; }
        public DateTime? FechaVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public int UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }

        
    }

}
