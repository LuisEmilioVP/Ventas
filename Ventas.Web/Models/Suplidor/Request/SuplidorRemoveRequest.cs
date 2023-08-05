namespace Ventas.Web.Models.Suplidor.Request
{
    public class SuplidorRemoveRequest : BaseRequest
    {
        public int IdSuplidor { get; set; }
        public bool Deleted { get; set; }

        public SuplidorRemoveRequest()
        {
        }

        public SuplidorRemoveRequest(int suplID)
        {
            this.IdSuplidor = suplID;
            this.Deleted = true;
        }
    }
}