using Ventas.Application.Dtos.Usuario;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.APIs.ApiServices
{
    public class UsuarioApiService : IUsuarioApiService
    {
        private readonly IApiRepository apiCaller;
        private readonly ILogger<UsuarioApiService> logger;
        private readonly string apiKey = "http://localhost:5203/api/Usuario/";
            
        public UsuarioApiService(IApiRepository apiCaller, ILogger<UsuarioApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public UsuarioListResponse Get()
        {
            UsuarioListResponse? usuarioListResponse = new();
            string urlApi = $" {apiKey}GetUsers";

            try
            {
                usuarioListResponse = apiCaller.Get(urlApi, usuarioListResponse);

                if (usuarioListResponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                usuarioListResponse = new UsuarioListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetUsers) a la Api, url: {urlApi}"
                };

                logger.LogError(usuarioListResponse.Message, ex.ToString());
            }

            return usuarioListResponse;
        }

        public UsuarioDetailsResponse GetById(int id)
        {
            UsuarioDetailsResponse? usuarioDetails = new();
            string urlApi = $" {apiKey}GetUserById?id={id}";

            try
            {
                usuarioDetails = apiCaller.Get(urlApi, usuarioDetails);

                if (usuarioDetails == null) throw new Exception();
            }
            catch (Exception ex)
            {
                usuarioDetails = new UsuarioDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {urlApi}"
                };
               
                logger.LogError(usuarioDetails.Message, ex.ToString());
            }

            return usuarioDetails;
        }

        public BaseResponse Add(UsuarioAddRequest add)
        {
            BaseResponse? response = new BaseResponse();

            UsuarioAddDto usuarioAdd = add.ConvertAddRequestToAddDto();
            string urlApi = $" {apiKey}SaveUser";

            try
            {
                response = apiCaller.Set(urlApi, usuarioAdd, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Add) a la Api, url: {urlApi}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Update(UsuarioUpdateRequest update)
        {
            BaseResponse? response = new BaseResponse();

            UsuarioUpdateDto usuarioUpdate = update.ConvertUpdateRequestToUpdateDto();
            string urlApi = $" {apiKey}UpdateUser";

            try
            {
                response = apiCaller.Set(urlApi, usuarioUpdate, response);

                if (response == null ) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Update) a la Api, url: {urlApi}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Remove(UsuarioRemoveRequest remove)
        {
            BaseResponse? response = new BaseResponse();

            UsuarioRevoveDto usuarioRevove = remove.ConvertRemoveDtoToRemoveRequest();
            string urlApi = $"  {apiKey}RemoveUser"; 

            try
            {
                response = apiCaller.Set(urlApi, usuarioRevove, response);

                if (response == null ) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Remove) a la Api, url: {urlApi}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }
    }
}
