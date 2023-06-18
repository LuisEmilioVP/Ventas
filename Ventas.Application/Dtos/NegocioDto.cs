using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Application.Dtos.Negocio
{
    public class NegocioDto : DtoSecon
    {
        public string? urlLogo { get; set; }
        public string? nombreLogo { get; set; }
        public string? numeroDocumento { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? direccion { get; set; }
        public decimal? porcentajeImpuesto { get; set; }
        public string? simboloMoneda { get; set; }
    }
}
