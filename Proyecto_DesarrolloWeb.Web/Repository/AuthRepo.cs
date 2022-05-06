using Newtonsoft.Json;
using Proyecto_DesarrolloWeb.Web.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Repository
{
    public class AuthRepo
    {
        public static async Task<ResponseCustomLogin> Login(Login usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Member/authentication", data);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<ResponseCustomLogin>(apiResponse);
            return responseDeserialize;
            //string apiResponse = await response.Content.ReadAsStringAsync();
            //var responseDeserialize = JsonConvert.DeserializeObject<string>(apiResponse);
            //return apiResponse;
        }

        public static async Task<ResponseCustom> Register(User usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Member/register", data);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<ResponseCustom>(apiResponse);
            return responseDeserialize;
        }
    }
}
