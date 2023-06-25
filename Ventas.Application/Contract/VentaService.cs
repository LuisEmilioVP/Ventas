using Ventas.Application.Core;
using Ventas.Application.Dtos.Venta;

namespace Ventas.Application.Contract
{
    public interface IVentaService : IBaseService<VentaAddDto,
                                                  VentaUpdateDto,
                                                  VentaRemoveDto>
    {
    }
}
