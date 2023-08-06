using Ventas.Web.APIs.ApiServices.Core;
using Ventas.Web.Models.Negocio.Request;
using Ventas.Web.Models.Negocio.Response;

namespace Ventas.Web.APIs.ApiServices.Interfaces
{
    public interface INegocioApiService : IApiService<NegocioListResponse,
                                                      NegocioDetailsResponse,
                                                      NegocioAddRequest,
                                                      NegocioUpdateRequest,
                                                      NegocioRemoveRequest>
    {
    }
}
