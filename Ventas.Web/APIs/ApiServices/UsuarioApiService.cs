using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.APIs.ApiServices
{
    public class UsuarioApiService : IUsuarioApiService
    {
        private readonly IApiCaller apiCaller;
        private readonly ILogger<UsuarioApiService> logger;
        private string bodyUrl = "http://localhost:5203/api/Usuario/";

        public UsuarioApiService(IApiCaller apiCaller, ILogger<UsuarioApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public UsuarioListResponse Get()
        {
            UsuarioListResponse? usuarioListResponse = new UsuarioListResponse();
            string url = $" {bodyUrl}GetUsers";

            try
            {
                usuarioListResponse = apiCaller.Get(url, usuarioListResponse);

                if (usuarioListResponse == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                usuarioListResponse = new UsuarioListResponse();

                usuarioListResponse.Success = false;
                usuarioListResponse.Message = $"Ocurrió un error en la solicitud a la Api, url: {url}";
                logger.LogError(usuarioListResponse.Message, ex.ToString());
            }

            return usuarioListResponse;
        }

        public UsuarioDetailsResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Add(UsuarioAddRequest add)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Update(UsuarioUpdateRequest update)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Remove(UsuarioRemoveRequest remove)
        {
            throw new NotImplementedException();
        }
    }
}
