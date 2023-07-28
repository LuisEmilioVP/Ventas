using Ventas.Application.Core;
using Ventas.Application.Dtos.DetalleVenta;


namespace Ventas.Application.Contract
{
    public interface IDetalleVentaService : IBaseService<DetalleVentaAddDto,
                                                       DetalleVentaUpdateDto,
                                                      DetalleVentaRemoveDto>
    {
    }
}