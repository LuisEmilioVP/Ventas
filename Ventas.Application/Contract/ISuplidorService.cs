
using Ventas.Application.Core;
using Ventas.Application.Dto.Suplidor;

namespace Ventas.Application.Contract
{
    public interface ISuplidorService : IBaseService<SuplidorAddDto, 
                                                     SuplidorUpdateDto, 
                                                     SuplidorRemoveDto>
    {
    }
}
