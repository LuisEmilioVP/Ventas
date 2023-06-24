using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Application.Core
{
    public interface IBaseService<DtoAdd, DtoUpdate, DtoRemover>
    {
        ServiceResult Get();
        ServiceResult GetById(int idproducto);
        ServiceResult Add(DtoAdd model);
        ServiceResult Update(DtoUpdate model);
        ServiceResult Remove(DtoRemover model);
    }
}
