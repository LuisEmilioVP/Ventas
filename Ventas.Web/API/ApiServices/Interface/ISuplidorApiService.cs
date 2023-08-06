using Ventas.Web.API.ApiServices.Core;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.API.ApiServices.Interface
{
    public interface ISuplidorApiService : IApiService<SuplidorListResponse,
                                                        SuplidorDetailsResponse,
                                                        SuplidorAddRequest,
                                                        SuplidorUpdateRequest,
                                                        SuplidorRemoveRequest>
    {
    }
}
