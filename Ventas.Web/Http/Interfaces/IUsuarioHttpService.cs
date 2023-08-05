using Ventas.Web.Http.Core;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Http.Interfaces
{
    public interface IUsuarioHttpService : IHttpService<UsuarioListResponse,
                                                        UsuarioDetailsResponse,
                                                        UsuarioAddRequest,
                                                        UsuarioUpdateRequest,
                                                        UsuarioRemoveRequest>
    {
    }
}
