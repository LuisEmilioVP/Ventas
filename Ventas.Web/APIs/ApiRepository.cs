using Newtonsoft.Json;
using System.Text;
using Ventas.Web.Models;

namespace Ventas.Web.APIs
{
    public class ApiRepository : IApiRepository
    {
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<ApiRepository> logger;


        public ApiRepository(ILogger<ApiRepository> logger)
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.logger = logger;
        }

        public ObjIn? Get<ObjIn>(string url, ObjIn? response) where ObjIn: BaseResponse
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var result = httpClient.GetAsync(url).Result)
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<ObjIn>(apiResponse);
                    }
                }
            }

            return response;
        }

        public ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn request, ObjOut? response) where ObjOut: BaseResponse
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                StringContent content = new(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var result = httpClient.PostAsync(url, content).Result)
                {
                    string apiResponse = result.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<ObjOut>(apiResponse);
                }

                return response;
            }
        }
    }
}
