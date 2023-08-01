

namespace Ventas.Application.Core
{
    public abstract class BaseService<ModelAdd, ModelMod, ModelRem>
    {
        public abstract ServiceResult Get();
        public abstract ServiceResult GetBuId(int id);
        public abstract ServiceResult Save(ModelAdd model);
        public abstract ServiceResult Delete(ModelMod model);
        public abstract ServiceResult Update(ModelRem model);
    }
}
