using Ventas.Web.Models;

namespace Ventas.Web.APIs
{
    public interface IApiRepository
    {
        ObjIn? Get<ObjIn>(string url, ObjIn request) where ObjIn: BaseResponse;
        ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn request, ObjOut response) where ObjOut: BaseResponse;
    }
}
