using Ventas.Web.APIs.ApiServices.Core;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.APIs.ApiServices.Interfaces
{
    public interface IProductoApiService : IApiService<ProductoListResponse, 
        ProductoDetailsResponse, 
        ProductoAddRequest, 
        ProductoUpdateRequest, 
        ProductoRemoveRequest>
    {
    }
}
