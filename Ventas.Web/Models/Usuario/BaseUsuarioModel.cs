namespace Ventas.Web.Models.Usuario
{
    public class BaseUsuarioModel
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Clave { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
