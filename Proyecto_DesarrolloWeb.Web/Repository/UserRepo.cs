using Proyecto_DesarrolloWeb.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Proyecto_DesarrolloWeb.Web.Repository
{
    public class UserRepo
    {
        public static async Task<ResponseCustomUser> GetUsers(string type)
        {
            /*var json = JsonConvert.SerializeObject(type);
            var data = new StringContent(json, Encoding.UTF8, "application/json");*/

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:26167/api/User/GetUsers/"+type);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<ResponseCustomUser>(apiResponse);
            return responseDeserialize;
        }
        public static async Task<ResponseCustom> AprobarUser(User usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/User/AprobarUser/", data);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<ResponseCustom>(apiResponse);
            return responseDeserialize;
        }
    }
}
