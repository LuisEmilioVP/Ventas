using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Producto : SeconEntity
    {
        public int idProducto { get; set; }
        public string? codigoBarra { get; set; }
        public string? marca { get; set; }
        public int? idCategoria { get; set;  }
        public int? idSuplidor { get; set; }
        public int? stock { get; set; }
        public string? urlImagen { get; set; }
        public string? nombreImagen { get; set; }
        public decimal? precio { get; set; }
        public DateTime? fechaRegistro { get; set; }
        






    }
}
