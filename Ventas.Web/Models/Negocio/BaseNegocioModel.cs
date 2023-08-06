namespace Ventas.Web.Models.Negocio
{
    public class BaseNegocioModel
    {
        public int idNegocio { get; set; }
        public string? urlLogo { get; set; }
        public string? nombreLogo { get; set; }
        public string? numeroDocumento { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public decimal? porcentajeImpuesto { get; set; }
        public string? simboloMoneda { get; set; }
    }
}
