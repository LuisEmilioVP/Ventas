
namespace Ventas.Application.Dtos.Venta
{
    public class VentaRemoveDto : DtoBase
    {
        public int IdVenta { get; set; }
        public bool Deleted { get; set; }
    }
}