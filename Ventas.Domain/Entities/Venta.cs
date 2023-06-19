using System;
using System.Collections.Generic;
using System.Text;
using Ventas.Domain.Core;


namespace Ventas.Domain.Entities
{
    public class Venta : SeconEntity
    {
        public object? IdVenta;

        public int NumeroVenta { get; set; }
        public int IdTipoDocumentoVenta { get; set; }
        public int IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
        public new DateTime FechaRegistro { get; set; }
        public object? FechaVenta { get; set; }
        public object? TotalVenta { get; set; }
    }
}
