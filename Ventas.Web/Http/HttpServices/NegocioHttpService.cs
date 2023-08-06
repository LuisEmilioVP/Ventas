using Ventas.Application.Dtos.Negocio;
using Ventas.Web.Controllers.Extensions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Negocio.Request;
using Ventas.Web.Models.Negocio.Response;

namespace Ventas.Web.Http.HttpServices
{
    public class NegocioHttpService : INegocioHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<NegocioHttpService> logger;
        private string baseUrl = string.Empty;

        public NegocioHttpService(IHttpRepository httpRepository,
                                  IConfiguration configuration,
                                  ILogger<NegocioHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            baseUrl = configuration["ApiConfig:baseUrl"];
        }
        public BaseResponse Add(NegocioAddRequest add)
        {
            BaseResponse? response = new();

            NegocioAddDto negocioAdd = add.ConvertAddRequestToAddDto();
            string url = $" {baseUrl}Negocio/SaveNegocio";

            try
            {
                response = httpRepository.Set(url, negocioAdd, response);

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

        public NegocioListResponse Get()
        {
            NegocioListResponse? response = new();
            string url = $" {baseUrl}Negocio/GetNegocio";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new NegocioListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public NegocioDetailsResponse GetById(int id)
        {
            NegocioDetailsResponse? response = new();
            string url = $" {baseUrl}Negocio/GetNegocioById?id={id}";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new NegocioDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Remove(NegocioRemoveRequest remove)
        {
            BaseResponse? response = new();

            NegocioRemoveDto negocioRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Negocio/RemoveUser";

            try
            {
                response = httpRepository.Set(url, negocioRemove, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Remove) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Update(NegocioUpdateRequest update)
        {
            BaseResponse? response = new();

            NegocioUpdateDto negocioUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Negocio/UpdateNegocio";

            try
            {
                response = httpRepository.Set(url, negocioUpdate, response);

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
    }
}
