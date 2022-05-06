using Newtonsoft.Json;
using Proyecto_DesarrolloWeb.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Repository
{
    public class ReportRepo
    {

        public static async Task<IEnumerable<ReportUserDTO>> GetAllUserReportAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Report/GetUserReport");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<ReportUserDTO>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<ReportUserDTO>> GetAllUserReportAsync(DateTime startDate, DateTime endDate)
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Report/GetUserReportDate?startDate="+ startDate.Date + "&endDate="+ endDate.Date);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<ReportUserDTO>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<ReportUserDTO>> GetAllUserReportAsync(string text)
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Report/GetUserReportName?text="+ text);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<ReportUserDTO>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<ReportPetDTO>> GetAllPetReportAsync(string startDate, string endDate, string owner, string petName, string status, int idPetType, int idPetAge, bool images = false)
        {
            using HttpClient httpClient = new HttpClient();
            //string url = "http://localhost:26167/api/Report/GetPetReport?" +
            //    (startDate == null ? "" : "startDate=" + startDate) +
            //    (endDate == null ? "" : "&endDate=" + endDate) +
            //    (owner == null ? "" : "&owner=" + owner) +
            //    (petName == null ? "" : "&petName=" + petName) +
            //    (status == null ? "" : "&status=" + status) +
            //    (idPetType == -1 ? "" : "&idPetType=" + idPetType + "") +
            //    (idPetAge == -1 ? "" : "&idPetAge=" + idPetAge) +
            //    (images == false ? "" : "&images=" + images);

            using var response = await httpClient.GetAsync("http://localhost:26167/api/Report/GetPetReport?" +
               (startDate == null ? "" : "startDate=" + startDate) +
                (endDate == null ? "" : "&endDate=" + endDate) +
                (owner == null ? "" : "&owner=" + owner) +
                (petName == null ? "" : "&petName=" + petName) +
                (status == null ? "" : "&status=" + status) +
                (idPetType == -1 ? "" : "&idPetType=" + idPetType + "") +
                (idPetAge == -1 ? "" : "&idPetAge=" + idPetAge) +
                (images == false ? "" : "&images=" + images));
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<ReportPetDTO>>(apiResponse);
            return responseDeserialize;
        }
    }
}
