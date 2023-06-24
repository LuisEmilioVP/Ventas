using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Application.Core
{
    public abstract class BaseService<ModelAdd, ModelUpdate, ModelRemove>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetById(int idproducto);
        public abstract ServiceResult Add(ModelAdd model);
        public abstract ServiceResult Update(ModelUpdate model);
        public abstract ServiceResult Remove(ModelRemove model);
    }
}
