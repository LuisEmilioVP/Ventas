
namespace Ventas.Application.Dtos.DetalleVenta
{
    public class DetalleVentaRemoveDto : DtoBase
    {
        public int IdVenta { get; set; }
        public bool Deleted { get; set; }
    }
}