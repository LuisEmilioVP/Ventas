namespace Ventas.Web.Models.Usuario.Request
{
    public class UsuarioRequest : BaseRequest
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Clave { get; set; }
    }
}
