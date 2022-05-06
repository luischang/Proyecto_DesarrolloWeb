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
    public class PetOperationsRepo
    {
        public static async Task<ResponseCustomGetDetalleMascota> GetDetalleMascota(Pet pet)
        {
            var json = JsonConvert.SerializeObject(pet);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Pet/GetDetailMascota/", data);

            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<ResponseCustomGetDetalleMascota>(apiResponse);
            return responseDeserialize;
        }
    }
}
