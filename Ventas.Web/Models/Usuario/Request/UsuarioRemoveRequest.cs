namespace Ventas.Web.Models.Usuario.Request
{
    public class UsuarioRemoveRequest : BaseRequest
    {
        public int IdUsuario { get; set; }
        public bool Deleted { get; set; }

        public UsuarioRemoveRequest() 
        {
        }

        public UsuarioRemoveRequest(int userId)
        {
            this.IdUsuario = userId;
            this.Deleted = true;
        }
    }
}
