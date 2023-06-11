using System;
using System.Collections.Generic;
using System.Text;


namespace Ventas.Domain.Core
{
    public abstract class Personventa  : BaseEntity
    {
        public string? NombreVenta { get; set; }

        public string?Idusuario { get; set; }

        public string? DocumentoCliente { get; set; }

        public string? fecharegistro { get; set; }
    }
}
