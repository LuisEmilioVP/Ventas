using Ventas.Application.Dtos.Categoria;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Categoria.Request;
using Ventas.Web.Models.Categoria.Response;

namespace Ventas.Web.Http.HttpServices
{
    public class CategoriaHttpService : ICategoriaHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<CategoriaHttpService> logger;
        private string baseUrl = string.Empty;

        public CategoriaHttpService(IHttpRepository httpRepository,
                                    IConfiguration configuration,
                                    ILogger<CategoriaHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }
        public CategoriaListResponse Get()
        {
            CategoriaListResponse? response = new();
            string url = $" {baseUrl}Categoria/GetCategory";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new CategoriaListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public CategoriaDetailsResponse GetById(int id)
        {
            CategoriaDetailsResponse? response = new();
            string url = $" {baseUrl}Categoria/GetCategoryById?id={id}";

            try
            {
                response = httpRepository.Get(url, response);

                if (response == null) throw new Exception();
            }
            catch (Exception ex)
            {
                response = new CategoriaDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(response.Message, ex.ToString());
            }

            return response;
        }

        public BaseResponse Add(CategoriaAddRequest add)
        {
            BaseResponse? response = new();

            CategoriaAddDto categoriaAdd = add.ConvertAddRequestToAddDto();
            string url = $" {baseUrl}Categoria/SaveCategory";

            try
            {
                response = httpRepository.Set(url, categoriaAdd, response);

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

        public BaseResponse Update(CategoriaUpdateRequest update)
        {
            BaseResponse? response = new();

            CategoriaUpdateDto categoriaUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Categoria/UpdateCategory";

            try
            {
                response = httpRepository.Set(url, categoriaUpdate, response);

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

        public BaseResponse Revome(CategoriaRemoveRequest remove)
        {
            BaseResponse? response = new();

            CategoriaRemoveDto categoriaRemove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Categoria/RemoveCategory";

            try
            {
                response = httpRepository.Set(url, categoriaRemove, response);

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
