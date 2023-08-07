namespace Ventas.Web.Models.Negocio.Request
{
    public class NegocioRemoveRequest : BaseRequest
    {
        public int idNegocio { get; set; }
        public bool Deleted { get; set; }

        public NegocioRemoveRequest()
        {
        }
        public NegocioRemoveRequest(int negoId)
        {
            this.idNegocio = negoId;
            this.Deleted = true;
        }
    }
}
