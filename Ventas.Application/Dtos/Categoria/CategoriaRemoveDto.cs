
namespace Ventas.Application.Dtos.Categoria
{
    public class CategoriaRemoveDto : DtoBase
    {
        public int IdCategoria { get; set; }
        public bool Deleted { get; set; }
    }
}
