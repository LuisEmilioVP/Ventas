using System.ComponentModel.DataAnnotations;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Usuario : SeconEntity
    {
        [Key] public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Clave { get; set; }
    }
}
