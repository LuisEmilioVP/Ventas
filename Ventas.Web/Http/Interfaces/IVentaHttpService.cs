using Ventas.Web.Http.Core;
using Ventas.Web.Models.Venta.Request;
using Ventas.Web.Models.Venta.Response;

namespace Ventas.Web.Http.Interfaces
{
    public interface IVentaHttpService : IHttpService<VentaListResponse,
                                                        VentaDetailsResponse,
                                                        VentaAddRequest,
                                                        VentaUpdateRequest,
                                                        VentaRemoveRequest>
    {
    }
}
