

namespace Ventas.Application.Dtos.Producto
{
    public class ProductoRemoveDto : DtosBase
    {
        public int IdProducto { get; set; }
        public bool Deleted { get; set; }

    }
}

