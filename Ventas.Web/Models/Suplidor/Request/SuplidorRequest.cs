namespace Ventas.Web.Models.Suplidor.Request
{
    public class SuplidorRequest : BaseRequest
    {
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string? Region { get; set; }
        public string? Codigo_postal { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public string? Fax { get; set; }
        
    }
}
