namespace Ventas.Web.Models
{
    public class BaseVentaModel
    {
        public int idVenta { get; set; }
        public string? numeroVenta { get; set; }
        //public int idTipoDocumentoVenta { get; set; }
        public int? idUsuario { get; set; }
        public string? documentoCliente { get; set; }
        public string? nombreCliente { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? impuestoTotal { get; set; }
        public decimal? Total { get; set; }
        public DateTime? fechaRegistro { get; set; }
        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
