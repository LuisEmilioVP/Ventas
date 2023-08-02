using Ventas.Application.Dtos.Categoria;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.APIs.ApiServices
{
    public class CategoriaApiService : ICategoriaApiService
    {
        private readonly IApiRepository apiCaller;
        private readonly ILogger<CategoriaApiService> logger;
        private readonly string apiKey = "http://localhost:5203/api/Categoria/";

        public CategoriaApiService(IApiRepository apiCaller, ILogger<CategoriaApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }

        public CategoriaListResponse Get()
        {
            CategoriaListResponse? categoriaList = new();
            string urlApi = $" {apiKey}GetCategory";

            try
            {
                categoriaList = apiCaller.Get(urlApi, categoriaList);

                if (categoriaList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                categoriaList = new CategoriaListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {urlApi}"
                };

                logger.LogError(categoriaList.Message, ex.ToString());
            }

            return categoriaList;
        }

        public CategoriaDetailsResponse GetById(int id)
        {
            CategoriaDetailsResponse? categoriaDetails = new();
            string urlApi = $" {apiKey}GetCategoryById?id={id}";

            try
            {
                categoriaDetails = apiCaller.Get(urlApi, categoriaDetails);

                if (categoriaDetails == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                categoriaDetails = new CategoriaDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {urlApi}"
                };

                logger.LogError(categoriaDetails.Message, ex.ToString());
            }

            return categoriaDetails;
        }

        public BaseResponse Add(CategoriaAddRequest add)
        {
            BaseResponse? response = new();

            CategoriaAddDto categoriaAdd = add.ConvertAddRequestToAddDto();
            string urlApi = $" {apiKey}SaveCategory";

            try
            {
                response = apiCaller.Set(urlApi, categoriaAdd, response);

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

        public BaseResponse Update(CategoriaUpdateRequest update)
        {
            BaseResponse? response = new();

            CategoriaUpdateDto categoriaUpdate = update.ConvertUpdateRequestToUpdateDto();
            string urlApi = $" {apiKey}UpdateCategory";

            try
            {
                response = apiCaller.Set(urlApi, categoriaUpdate, response);

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

        public BaseResponse Remove(CategoriaRemoveRequest remove)
        {
            BaseResponse? response = new();

            CategoriaRemoveDto categoriaRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string urlApi = $" {apiKey}RemoveCategory";

            try
            {
                response = apiCaller.Set(urlApi, categoriaRemove, response);

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
