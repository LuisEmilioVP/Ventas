using Ventas.Application.Dto.Venta;
using Ventas.Web.Controllers.Extentions;
using Ventas.Web.Http.Interfaces;
using Ventas.Web.Models;
using Ventas.Web.Models.Venta.Request;
using Ventas.Web.Models.Venta.Response;

namespace Ventas.Web.Http.HttpServices
{
    public class VentaHttpService : IVentaHttpService
    {
        private readonly IHttpRepository httpRepository;
        private readonly ILogger<VentaHttpService> logger;
        private string baseUrl = string.Empty;

        //http://localhost:5203/api/Usuario/GetUsers

        public VentaHttpService(IHttpRepository httpRepository,
                                  IConfiguration configuration,
                                  ILogger<VentaHttpService> logger)
        {
            this.httpRepository = httpRepository;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public VentaListResponse Get()
        {
            VentaListResponse? ventaList = new();
            string url = $" {baseUrl}Usuario/GetUsers";

            try
            {
                ventaList = httpRepository.Get(url, ventaList);

                if (ventaList == null) throw new Exception();
            }
            catch (Exception ex)
            {
                ventaList = new VentaListResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (Get) a la Api, url: {url}"
                };
             
                logger.LogError(ventaList.Message, ex.ToString());
            }

            return ventaList;
        }

        public VentaDetailsResponse GetById(int id)
        {
            VentaDetailsResponse? ventaDetails = new();
            string url = $" {baseUrl}Venta/GetUserById?id={id}";

            try
            {
                ventaDetails = httpRepository.Get(url, ventaDetails);

                if (ventaDetails == null) throw new Exception();

            }
            catch (Exception ex)
            {
                ventaDetails = new VentaDetailsResponse
                {
                    Success = false,
                    Message = $"Ocurrió un error en la solicitud (GetById) a la Api, url: {url}"
                };

                logger.LogError(ventaDetails.Message, ex.ToString());
            }

            return ventaDetails;
        }

        public BaseResponse Add(VentaAddRequest add)
        {
            BaseResponse? response = new();

            VentaAddDto usuarioAdd = add.ConvertAddRequestToAddDto();
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

        public BaseResponse Update(VentaUpdateRequest update)
        {
            BaseResponse? response = new();

            VentaUpdateDto ventaUpdate = update.ConvertUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Venta/UpdateUser";

            try
            {
                response = httpRepository.Set(url, ventaUpdate, response);

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

        public BaseResponse Revome(VentaRemoveRequest remove)
        {
            BaseResponse? response = new();

            VentaRevoveDto ventaRevove = remove.ConvertRemoveDtoToRemoveRequest();
            string url = $" {baseUrl}Venta/RemoveUser";

            try
            {
                response = httpRepository.Set(url, ventaRevove, response);

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
