using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Negocio.Request;
using Ventas.Web.Models.Negocio.Response;

namespace Ventas.Web.APIs.ApiServices
{
    public class NegocioApiService : INegocioApiService
    {
        private readonly IApiRepository apiCaller;
        private readonly ILogger<NegocioApiService> logger;
        private readonly string apiKey = "http://localhost:5203/api/Negocio/";

        public NegocioApiService(IApiRepository apiCaller, ILogger<NegocioApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public BaseResponse Add(NegocioAddRequest add)
        {
            throw new NotImplementedException();
        }

        public NegocioListResponse Get()
        {
            throw new NotImplementedException();
        }

        public NegocioDetailsResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Remove(NegocioRemoveRequest remove)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Update(NegocioUpdateRequest update)
        {
            throw new NotImplementedException();
        }
    }
}
