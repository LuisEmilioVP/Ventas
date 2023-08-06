using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Infrastructure.Models
{
    public class VentaModels
    {
        public int? IdVenta { get; set; }
        public string? NumeroVenta { get; set; }
        public int? IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }

        public DateTime? FechaVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public DateTime? FechaRegistro { get; set; }
        // public int idProducto { get; set; }
        //public string? marca { get; set; }
        // public string? descripcion { get; set; }
        //public string? precio { get; set; }



    }
}
