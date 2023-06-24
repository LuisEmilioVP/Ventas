using Ventas.Application.Core;
using Ventas.Application.Dtos.Categoria;

namespace Ventas.Application.Contract
{
    public interface ICategoriaService : IBaseService<CategoriaAddDto,
                                                       CategoriaUpdateDto,
                                                       CategoriaRemoveDto>
    {
    }
}
