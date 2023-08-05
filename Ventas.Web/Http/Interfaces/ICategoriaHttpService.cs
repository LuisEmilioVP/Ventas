using Ventas.Web.Http.Core;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.Http.Interfaces
{
    public interface ICategoriaHttpService : IHttpService<CategoriaListResponse,
                                                          CategoriaDetailsResponse,
                                                          CategoriaAddRequest,
                                                          CategoriaUpdateRequest,
                                                          CategoriaRemoveRequest>
    {
    }
}
