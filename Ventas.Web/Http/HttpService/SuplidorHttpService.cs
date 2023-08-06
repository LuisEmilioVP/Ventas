using Ventas.Application.Dto.Suplidor;
using Ventas.Web.Controllers.Extention;
using Ventas.Web.Http.Interface;
using Ventas.Web.Models;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.Http.HttpService
{
    public class SuplidorHttpService : ISuplidorHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<SuplidorHttpService> logger;
        private string baseUrl = string.Empty;

        public SuplidorHttpService(IHttpRepository httpRepository,
                                    IConfiguration configuration,
                                    ILogger<SuplidorHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }
        public SuplidorListResponse Get()
        {
            SuplidorListResponse? response = new();
            string url = $" {baseUrl}Suplidor/GetSuplidor";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new SuplidorListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public SuplidorDetailsResponse GetById(int id)
        {
            SuplidorDetailsResponse? response = new();
            string url = $" {baseUrl}Suplidor/IdSuplidor?id={id}";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new SuplidorDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Add(SuplidorAddRequest add)
        {
            BaseResponse? response = new();

            SuplidorAddDto suplidorAdd = add.ConvertAddRequestToAddDto();
            string url = $" {baseUrl}Suplidor/SaveSuplidor";

            try
            {
                response = httpRepository.Set(url, suplidorAdd, response);

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

        public BaseResponse Update(SuplidorUpdateRequest update)
        {
            BaseResponse? response = new();

            SuplidorUpdateDto suplidorUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Suplidor/UpdateSuplidor";

            try
            {
                response = httpRepository.Set(url, suplidorUpdate, response);

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

        public BaseResponse Revome(SuplidorRemoveRequest remove)
        {
            BaseResponse? response = new();

            SuplidorRemoveDto suplidorRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Suplidor/RemoveSuplidor";

            try
            {
                response = httpRepository.Set(url, suplidorRemove, response);

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
