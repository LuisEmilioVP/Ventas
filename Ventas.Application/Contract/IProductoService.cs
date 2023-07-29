

using Ventas.Application.Core;
using Ventas.Application.Dtos.Producto;

namespace Ventas.Application.Contract
{
    public interface IProductoService : IBaseService<ProductoAddDto, ProductoUpdateDto, ProductoRemoveDto>
    {

    }
}
