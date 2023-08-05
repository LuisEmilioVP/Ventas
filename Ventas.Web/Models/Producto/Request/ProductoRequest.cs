namespace Ventas.Web.Models.Producto.Request
{
    public class ProductoRequest : BaseRequest
    {
        public int IdProducto { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }

        //public string? NombreSuplidor { get; set; }
        //public string? CategoriaDescripcion { get; set; }
    }
}
