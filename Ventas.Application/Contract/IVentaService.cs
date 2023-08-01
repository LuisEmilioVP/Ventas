
using Ventas.Application.Core;
using Ventas.Application.Dto.Venta;

namespace Ventas.Application.Contract
{
    public interface IVentaService : IBaseService<VentaAddDto,
                                                     VentaUpdateDto,
                                                     VentaRemoveDto>
    {
    }
}
