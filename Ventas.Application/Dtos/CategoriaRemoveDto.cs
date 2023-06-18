
namespace Ventas.Application.Dtos.Negocio
{
    public class NegocioRemoveDto : DtoBase
    {
        public int idNegocio { get; set; }
        public bool Deleted { get; set; }
    }
}
