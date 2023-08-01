using Ventas.Web.APIs.ApiServices.Core;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.APIs.ApiServices.Interfaces
{
    public interface IUsuarioApiService : IApiService<UsuarioListResponse,
                                                      UsuarioDetailsResponse,
                                                      UsuarioAddRequest,
                                                      UsuarioUpdateRequest,
                                                      UsuarioRemoveRequest>
    {                               
    }
}
