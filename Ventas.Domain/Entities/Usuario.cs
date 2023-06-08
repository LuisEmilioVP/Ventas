using System;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Usuario : SeconEntity
    {
        public int IdUsuario { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
        public string? Clave { get; set; }
    }
}
