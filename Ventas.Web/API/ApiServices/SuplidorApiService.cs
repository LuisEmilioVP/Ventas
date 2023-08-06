using Ventas.Application.Dto.Suplidor;
using Ventas.Web.API.ApiServices.Interface;
using Ventas.Web.Controllers.Extention;
using Ventas.Web.Models;
using Ventas.Web.Models.Suplidor.Request;
using Ventas.Web.Models.Suplidor.Response;

namespace Ventas.Web.API.ApiServices
{
    public class SuplidorApiService : ISuplidorApiService
    {
        private readonly IApiRepository apiCaller;
        private readonly ILogger<SuplidorApiService> logger;
        private readonly string apiKey = "http://localhost:5203/api/Suplidor/";

        public SuplidorApiService(IApiRepository apiCaller, ILogger<SuplidorApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public SuplidorListResponse Get()
        {
            SuplidorListResponse? suplidorList = new();
            string urlApi = $" {apiKey}GetSuplidor";

            try
            {
                suplidorList = apiCaller.Get(urlApi, suplidorList);

                if (suplidorList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                suplidorList = new SuplidorListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {urlApi}"
                };

                logger.LogError(suplidorList.Message, ex.ToString());
            }

            return suplidorList;
        }

        public SuplidorDetailsResponse GetById(int id)
        {
            SuplidorDetailsResponse? suplidorDetails = new();
            string urlApi = $" {apiKey}IdSuplidor?id={id}";

            try
            {
                suplidorDetails = apiCaller.Get(urlApi, suplidorDetails);

                if (suplidorDetails == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                suplidorDetails = new SuplidorDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {urlApi}"
                };

                logger.LogError(suplidorDetails.Message, ex.ToString());
            }

            return suplidorDetails;
        }

        public BaseResponse Add(SuplidorAddRequest add)
        {
            BaseResponse? response = new();

            SuplidorAddDto suplidorAdd = add.ConvertAddRequestToAddDto();
            string urlApi = $" {apiKey}SaveSuplidor";

            try
            {
                response = apiCaller.Set(urlApi, suplidorAdd, response);

                if (response == null)
                    throw new Exception();
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

        public BaseResponse Update(SuplidorUpdateRequest update)
        {
            BaseResponse? response = new();

            SuplidorUpdateDto suplidorUpdate = update.ConvertUpdateRequestToUpdateDto();
            string urlApi = $" {apiKey}UpdateSuplidor";

            try
            {
                response = apiCaller.Set(urlApi, suplidorUpdate, response);

                if (response == null)
                    throw new Exception();
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

        public BaseResponse Remove(SuplidorRemoveRequest remove)
        {
            BaseResponse? response = new();

            SuplidorRemoveDto suplidorRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string urlApi = $" {apiKey}RemoveSuplidor";

            try
            {
                response = apiCaller.Set(urlApi, suplidorRemove, response);

                if (response == null)
                    throw new Exception();
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
