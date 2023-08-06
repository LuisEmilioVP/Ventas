using Newtonsoft.Json;
using System.Text;
using Ventas.Web.Models;

namespace Ventas.Web.Http
{
    public class HttpRepository : IHttpRepository
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpRepository(IHttpClientFactory httpClientFactory, ILogger<HttpRepository> logger)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public ObjIn? Get<ObjIn>(string url, ObjIn? response) where ObjIn : BaseResponse
        {
            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                using (var result = httpClient.GetAsync(url).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<ObjIn>(apiResponse);
                    }
                }
            }

            return response;
        }

        public ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn request, ObjOut? response) where ObjOut : BaseResponse
        {
            using (var httpClient = this.httpClientFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var result = httpClient.PostAsync(url, content).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;

                        response = JsonConvert.DeserializeObject<ObjOut>(apiResponse);
                    }
                }
            }
            return response;
        }
    }
}

