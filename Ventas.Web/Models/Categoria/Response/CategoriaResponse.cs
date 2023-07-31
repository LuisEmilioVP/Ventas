namespace Ventas.Web.Models.Categoria.Response
{
    public class CategoriaResponse
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
