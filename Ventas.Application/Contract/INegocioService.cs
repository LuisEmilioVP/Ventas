using Ventas.Application.Core;
using Ventas.Application.Dtos.Negocio;

namespace Ventas.Application.Contract
{
    public interface INegocioService : IBaseService<NegocioAddDto, NegocioUpdateDto, NegocioRemoveDto>
    {
    }
}