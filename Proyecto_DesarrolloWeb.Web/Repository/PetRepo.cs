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
    public class PetRepo
    {

        public static async Task<IEnumerable<PetType>> GetPetsTypeAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetPetsType");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<PetType>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<PetAge>> GetPetsAgeAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetPetsAge");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<PetAge>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<PetBreed>> GetPetsBreedAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetPetsBreed");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<PetBreed>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<IEnumerable<PetSize>> GetPetsSizeAsync()
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetPetsSize");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<PetSize>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<bool> RegisterPetAsync(Pet pet)
        {
            var json = JsonConvert.SerializeObject(pet);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Pet/PostPet", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<bool>(apiResponse);

            return responseDeserialize;
        }
        public static async Task<IEnumerable<Pet>> GetUserPetsAsync(int userId)
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetUserPets?userId="+userId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<Pet>>(apiResponse);
            return responseDeserialize;
        }
        //
        public static async Task<IEnumerable<LostPet>> GetUserLostPetsAsync(int userId)
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetLostPets?userId=" + userId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<LostPet>>(apiResponse);
            return responseDeserialize;
        }

        public static async Task<bool> RegisterLostPetAsync(LostPet lostPet)
        {
            var json = JsonConvert.SerializeObject(lostPet);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Pet/PostRegisterLostPet", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<bool>(apiResponse);

            return responseDeserialize;
        }
        //
        public static async Task<bool> RegisterFoundPetAsync(LostPet lostPet)
        {
            var json = JsonConvert.SerializeObject(lostPet);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Pet/PostRegisterFoundPet", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<bool>(apiResponse);

            return responseDeserialize;
        }


        //GetUserPetsAdoptionAsync
        public static async Task<IEnumerable<Pet>> GetUserPetsAdoptionAsync(int userId)
        {
            using HttpClient httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("http://localhost:26167/api/Pet/GetUserPets?userId=" + userId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<IEnumerable<Pet>>(apiResponse);
            return responseDeserialize;
        }
        //
        public static async Task<bool> RegisterPetAdoptionAsync(PetAdoption pet)
        {
            var json = JsonConvert.SerializeObject(pet);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:26167/api/Pet/PostRegisterPetAdoption", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var responseDeserialize = JsonConvert.DeserializeObject<bool>(apiResponse);

            return responseDeserialize;
        }
    }
}
