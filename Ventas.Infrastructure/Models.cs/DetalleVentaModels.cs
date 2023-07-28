using System;


namespace DetalleVentas.Infrastructure.Models.cs
{
    internal class DetalleVentaModels
    {


        
            public string? NumeroVenta { get; set; }
            public int idDetalleVenta { get; set; }
            public int idVenta { get; set; }
            public string? marcaProducto { get; set; }
            public string? descripcionProducto { get; set; }
            public string? categoriaProducto { get; set; }
            public decimal cantidad { get; set; }
            public decimal precio { get; set; }
            public decimal Total { get; set; }
            public DateTime? FechaRegistro { get; set; }
      
    }

}
