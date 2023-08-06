using Ventas.Web.Models;

namespace Ventas.Web.Http
{
    public interface IHttpRepository
    {
        ObjIn? Get<ObjIn>(string url, ObjIn response) where ObjIn : BaseResponse;
        ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn request, ObjOut response) where ObjOut : BaseResponse;
    }
}
