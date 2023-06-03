using System;
using System.Runtime.CompilerServices;
using Ventas.Domain.Core;

namespace Ventas.Domain.Entities
{
    public class Suplidor : Persona
    {

        public int? idSuplidor { get; set; }
        public string? contact { get; set; }
        public string? city { get; set; }
        public string region { get; set; }
        public string Postal_Code { get; set; }
        public string? country { get; set; }
        public string fax { get; set; }

    }
}
