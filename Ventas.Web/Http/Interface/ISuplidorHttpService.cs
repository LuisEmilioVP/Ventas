using Ventas.Web.Http.Core;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.Http.Interface
{
    public interface ISuplidorHttpService : IHttpService<SuplidorListResponse,
                                                          SuplidorDetailsResponse,
                                                          SuplidorAddRequest,
                                                          SuplidorUpdateRequest,
                                                          SuplidorRemoveRequest>
    {
    }
}
