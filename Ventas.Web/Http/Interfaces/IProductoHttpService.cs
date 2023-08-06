using Ventas.Web.Http.Core;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.Http.Interfaces
{
    public interface IProductoHttpService : IHttpService<ProductoListResponse, 
        ProductoDetailsResponse, 
        ProductoAddRequest, 
        ProductoUpdateRequest, 
        ProductoRemoveRequest>
    {
    }
}
