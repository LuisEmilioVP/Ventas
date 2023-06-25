﻿using System;

namespace Ventas.Application.Dtos.Venta
{
    public class VentaDto : DtoSecon
    {
        public string? NumeroVenta { get; set; }
        public int IdTipoDocumentoVenta { get; set; }
        public int IdUsuario { get; set; }
        public string? DocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}