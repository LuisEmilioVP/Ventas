using System.ComponentModel.DataAnnotations;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Categoria : SeconEntity
    {
        [Key] public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
    }
}
