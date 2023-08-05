using Ventas.Application.Dtos.Usuario;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Usuario.Request;
using Ventas.Web.Models.Usuario.Response;

namespace Ventas.Web.Http.HttpServices
{
    public class UsuarioHttpService : IUsuarioHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<UsuarioHttpService> logger;
        private string baseUrl = string.Empty;

        public UsuarioHttpService(IHttpRepository httpRepository,
                                  IConfiguration configuration,
                                  ILogger<UsuarioHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public UsuarioListResponse Get()
        {
            UsuarioListResponse? usuarioList = new();
            string url = $" {baseUrl}Usuario/GetUsers";

            try
            {
                usuarioList = httpRepository.Get(url, usuarioList);

                if (usuarioList == null) throw new Exception();
            }
            catch (Exception ex)
            {
                usuarioList = new UsuarioListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };
             
                logger.LogError(usuarioList.Message, ex.ToString());
            }

            return usuarioList;
        }

        public UsuarioDetailsResponse GetById(int id)
        {
            UsuarioDetailsResponse? usuarioDetails = new();
            string url = $" {baseUrl}Usuario/GetUserById?id={id}";

            try
            {
                usuarioDetails = httpRepository.Get(url, usuarioDetails);

                if (usuarioDetails == null) throw new Exception();

            }
            catch (Exception ex)
            {
                usuarioDetails = new UsuarioDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(usuarioDetails.Message, ex.ToString());
            }

            return usuarioDetails;
        }

        public BaseResponse Add(UsuarioAddRequest add)
        {
            BaseResponse? response = new();

            UsuarioAddDto usuarioAdd = add.ConvertAddRequestToAddDto();
            string url = $" {baseUrl}Usuario/SaveUser";

            try
            {
                response = httpRepository.Set(url, usuarioAdd, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Add) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Update(UsuarioUpdateRequest update)
        {
            BaseResponse? response = new();

            UsuarioUpdateDto usuarioUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Usuario/UpdateUser";

            try
            {
                response = httpRepository.Set(url, usuarioUpdate, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Update) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Revome(UsuarioRemoveRequest remove)
        {
            BaseResponse? response = new();

            UsuarioRevoveDto usuarioRevove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Usuario/RemoveUser";

            try
            {
                response = httpRepository.Set(url, usuarioRevove, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Revome) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }
    }
}
