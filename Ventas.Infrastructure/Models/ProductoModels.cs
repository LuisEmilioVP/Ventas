using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Infrastructure.Models
{
    public class ProductoModels
    {
        public int IdProducto { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? ProductoDescripcion { get; set; }
        public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdSuplidor { get; set; }
        public string NombreSuplidor { get; set; }
        public int? IdCategoria { get; set; }
        public string? CategoriaDescripcion { get; set; }



    }
}
