using Newtonsoft.Json;
using System.Text;
using Ventas.Web.Models;

namespace Ventas.Web.APIs
{
    public class ApiCallerRepository : IApiCaller
    {
        HttpClientHandler handler = new HttpClientHandler();

        private readonly ILogger<ApiCallerRepository> logger;

        public ApiCallerRepository(ILogger<ApiCallerRepository> logger)
        {
            handler.ServerCertificateCustomValidationCallback = (
                sender, cert, chain, sslPolicyError) => { return true; };
            this.logger = logger;
        }

        public ObjIn? Get<ObjIn>(string url, ObjIn? objIn) where ObjIn : BaseResponse
        {
            using (var httpClient = new HttpClient(handler)) 
            {
                using (var response =  httpClient.GetAsync(url).Result) 
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        objIn = JsonConvert.DeserializeObject<ObjIn>(apiResponse);
                    }
                }
            }

            return objIn;
        }

        public ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn objIn, ObjOut? objOut) where ObjOut : BaseResponse
        {
            using (var httpClient = new HttpClient(handler))
            {
                StringContent content = new StringContent(JsonConvert.
                    SerializeObject(objIn), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync(url, content).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    objOut = JsonConvert.DeserializeObject<ObjOut>(apiResponse);
                }
                return objOut;
            }
        }
    }
}
