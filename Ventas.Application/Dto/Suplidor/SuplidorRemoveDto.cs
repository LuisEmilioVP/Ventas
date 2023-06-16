using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Application.Dto.Suplidor
{
    public class SuplidorRemoveDto : DtoBase
    {
        public int IdSuplidor { get; set; }
        public bool Deleted  { get; set; }
    }
}
