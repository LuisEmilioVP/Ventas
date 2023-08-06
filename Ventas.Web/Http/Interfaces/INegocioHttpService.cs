using Ventas.Web.Http.Core;
using Ventas.Web.Models.Negocio.Request;
using Ventas.Web.Models.Negocio.Response;

namespace Ventas.Web.Http.Interfaces
{
    public interface INegocioHttpService : IHttpService<NegocioListResponse,
                                                        NegocioDetailsResponse,
                                                        NegocioAddRequest,
                                                        NegocioUpdateRequest,
                                                        NegocioRemoveRequest>
    {
    }
}
