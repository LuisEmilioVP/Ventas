using System;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Usuario : Persona
    {
        public int IdUser { get; set; }
        public string? UrlPhoto { get; set; }
        public string? NamePhoto { get; set; }
        public string? Password {get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
