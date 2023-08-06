namespace Ventas.Web.Models.Venta.Request
{
    public class VentaRemoveRequest : BaseRequest
    {
        public int IdVenta { get; set; }
        public bool Deleted { get; set; }

        public VentaRemoveRequest() 
        {
        }

        public VentaRemoveRequest(int userId)
        {
            this.IdVenta = userId;
            this.Deleted = true;
        }
    }
}
