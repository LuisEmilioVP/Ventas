
using System;

namespace Ventas.Infrastructure.Models
{
    public class UsuarioModels
    {
        public int IdUsuario { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
        public string? Clave { get; set; }

        public int IdNegocio { get; set; }
        public string NombreNegocio { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioEdicion { get; set; }
        public DateTime FechaEdicion { get; set; }
    }
}
