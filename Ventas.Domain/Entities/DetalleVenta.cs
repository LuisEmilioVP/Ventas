using System;
using System.ComponentModel.DataAnnotations;


namespace DetalleVentas.Domain.Entities
{
    public class DetalleVenta
    {

        [Key] public int IdVenta { get; set; }
        public string? NumeroVenta { get; set; }
        public int idDetalleVenta { get; set; }
        public int idProducto { get; set; }
        public string? marcaProducto { get; set; }
        public string? descripcionProducto { get; set; }

        public string? categoriaProducto { get; set; }
        public decimal cantidad { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
    
        public decimal? precio { get; set; }
        public int UserDeleted { get; set; }

        public int CreationUser { get; set; }
        public int CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }


    }

}
