using Ventas.Web.Models;

namespace Ventas.Web.Http.Core
{
    public interface IHttpService<List, Details, TAdd, TUpdate, TRemove>
    {
        public List Get();
        public Details GetById(int id);
        public BaseReponse Add(TAdd add);
        public BaseReponse Update(TUpdate update);
        public BaseReponse Remove(TRemove remove);
    }
}
