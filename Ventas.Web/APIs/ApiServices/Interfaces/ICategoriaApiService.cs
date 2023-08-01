using Ventas.Web.APIs.ApiServices.Core;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.APIs.ApiServices.Interfaces
{
    public interface ICategoriaApiService : IApiService<CategoriaListResponse,
                                                        CategoriaDetailsResponse,
                                                        CategoriaAddRequest,
                                                        CategoriaUpdateRequest,
                                                        CategoriaRemoveRequest>
    {
    }
}
