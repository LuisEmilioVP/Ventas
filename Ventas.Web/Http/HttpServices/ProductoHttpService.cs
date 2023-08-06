using Ventas.Application.Dtos.Producto;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Producto.Request;
using Ventas.Web.Models.Producto.Response;

namespace Ventas.Web.Http.HttpServices
{
    public class ProductoHttpService : IProductoHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<ProductoHttpService> logger;
        private string baseUrl = string.Empty;

        public ProductoHttpService(IHttpRepository httpRepository, IConfiguration configuration, ILogger<ProductoHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public BaseReponse Add(ProductoAddRequest add)
        {
            BaseReponse? reponse = new();

            ProductoAddDto productoAdd = add.ConverAddRequestToAddDto();
            string url = $" {baseUrl}Producto/SaveProducto";

            try
            {
                reponse = httpRepository.Set(url, productoAdd, reponse);

                if (reponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new BaseReponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Add) a la Api, url: {url}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }

        public ProductoListResponse Get()
        {
            ProductoListResponse? productoList = new();
            string url = $" {baseUrl}Producto/GetProducto";

            try
            {
                productoList = httpRepository.Get(url, productoList);

                if (productoList == null) throw new Exception();
            }
            catch (Exception ex)
            {
                productoList = new ProductoListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };

                logger.LogError(productoList.Message, ex.ToString());
            }

            return productoList;


        }

        public ProductoDetailsResponse GetById(int id)
        {
            ProductoDetailsResponse? productoDetails = new();
            string url = $" {baseUrl}Producto/GetById?id={id}";

            try
            {
                productoDetails = httpRepository.Get(url, productoDetails);

                if (productoDetails == null) throw new Exception();

            }
            catch (Exception ex)
            {
                productoDetails = new ProductoDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(productoDetails.Message, ex.ToString());
            }

            return productoDetails;
        }

        public BaseReponse Remove(ProductoRemoveRequest remove)
        {
            BaseReponse? reponse = new();

            ProductoRemoveDto productoRemove = remove.ConverRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Producto/RemoveProducto";

            try
            {
                reponse = httpRepository.Set(url, productoRemove, reponse);

                if (reponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new BaseReponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Revome) a la Api, url: {url}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }

        public BaseReponse Update(ProductoUpdateRequest update)
        {
            BaseReponse? reponse = new();

            ProductoUpdateDto productoUpdate = update.ConverUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Producto/UpdateProducto";


            try
            {
                reponse = httpRepository.Set(url, productoUpdate, reponse);

                if (reponse == null) throw new Exception();
            }
            catch (Exception ex)
            {
                reponse = new BaseReponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Update) a la Api, url: {url}"
                };

                logger.LogError(reponse.Message, ex.ToString());
            }

            return reponse;
        }
    }
}
