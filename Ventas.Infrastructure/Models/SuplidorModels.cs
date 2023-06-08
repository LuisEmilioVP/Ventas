using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Infrastructure.Models
{
    public class SuplidorModels
    {
        public int IdSuplidor { get; set; }
        public string Contacto { get; set; }
        public string Ciudad { get; set; }
        public string? Region { get; set; }
        public string? Codigo_postal { get; set; }
        public string Pais { get; set; }
        public string? Fax { get; set; }

        public int idProducto { get; set; }
        public string? marca { get; set;}
        public string? descripcion { get; set;}
        public string? precio { get; set; }

    }
}
