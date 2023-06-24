using Ventas.Application.Core;
using Ventas.Application.Dtos.Usuario;

namespace Ventas.Application.Contract
{
    public interface IUsuarioService : IBaseService<UsuarioAddDto, 
                                                    UsuarioUpdateDto,
                                                    UsuarioRevoveDto>
    {
    }
}
