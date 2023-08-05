using Ventas.Application.Dtos.Producto;
using Ventas.Web.APIs.ApiServices.Interfaces;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Models;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.APIs.ApiServices
{
    public class ProductoApiService : IProductoApiService
    {
        private readonly IApiRepository apiCaller;
        private readonly ILogger<ProductoApiService> logger;
        private readonly string apiKey = "http://localhost:5203/api/Producto/";

        public ProductoApiService(IApiRepository apiCaller, ILogger<ProductoApiService> logger)
        {
            this.apiCaller = apiCaller;
            this.logger = logger;
        }
        public BaseReponse Add(ProductoAddRequest add)
        {
            BaseReponse? reponse = new BaseReponse();

            ProductoAddDto productoAdd = add.ConverAddRequestToAddDto();
            string urlApi = $" {apiKey}SaveProducto";

            try
            {
                reponse = apiCaller.Set(urlApi, productoAdd, reponse);

                if (reponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Add) a la Api, url: {urlApi}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }

        public ProductoListResponse Get()
        {
            ProductoListResponse? productoListResponse = new();
            string urlApi = $" {apiKey}GetProducto";

            try
            {
                productoListResponse = apiCaller.Get(urlApi, productoListResponse);

                if (productoListResponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                productoListResponse = new ProductoListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetProducto) a la Api, url: {urlApi}"
                };

                logger.LogError(productoListResponse.Message, ex.ToString());
            }

            return productoListResponse;
        }

        public ProductoDetailsResponse GetById(int id)
        {
            ProductoDetailsResponse? productoDetails = new();
            string urlApi = $" {apiKey}GetById?id={id}";

            try
            {
                productoDetails = apiCaller.Get(urlApi, productoDetails);

                if (productoDetails == null) throw new Exception();
            }
            catch (Exception ex)
            {
                productoDetails = new ProductoDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {urlApi}"
                };

                logger.LogError(productoDetails.Message, ex.ToString());
            }

            return productoDetails;

        }

        public BaseReponse Remove(ProductoRemoveRequest remove)
        {
            BaseReponse? reponse = new BaseReponse();

            ProductoRemoveDto productoRemove = remove.ConverRemoveDtoToRemoveRequest();
            string urlApi = $" {apiKey}RemoveProducto";

            try
            {
                reponse = apiCaller.Set(urlApi, productoRemove, reponse);

                if (reponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Remove) a la Api, url: {urlApi}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }

        public BaseReponse Update(ProductoUpdateRequest update)
        {
            BaseReponse? reponse = new BaseReponse();

            ProductoUpdateDto productoUpdate = update.ConverUpdateRequestToUpdateDto();
            string urlApi = $" {apiKey}UpdateProducto";

            try
            {
                reponse = apiCaller.Set(urlApi, productoUpdate, reponse);

                if (productoUpdate == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new()
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Update) a la Api, url: {urlApi}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }
    }
}
