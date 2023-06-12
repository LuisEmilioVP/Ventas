using System;

namespace Ventas.Infrastructure.Models
{
    public class CategoriaModels
    {
        public int IdCategoria { get; set; } 
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
