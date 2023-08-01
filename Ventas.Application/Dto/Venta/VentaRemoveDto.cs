using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Application.Dto.Venta
{
    public class VentaRemoveDto : DtoBase
    {
        public int IdVenta { get; set; }
        public bool Deleted  { get; set; }
    }
}
