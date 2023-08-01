namespace Ventas.Web.Models.Categoria
{
    public class BaseCategoriaModel
    {
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
