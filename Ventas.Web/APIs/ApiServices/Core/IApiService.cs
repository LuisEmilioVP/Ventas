using Ventas.Web.Models;

namespace Ventas.Web.APIs.ApiServices.Core
{
    public interface IApiService<List, Details, TAdd, TUpdate, TRemove>
    {
        public List Get();
        public Details GetById(int id);
        public BaseReponse Add(TAdd add);
        public BaseReponse Update(TUpdate update);
        public BaseReponse Remove(TRemove remove);
    }
}
