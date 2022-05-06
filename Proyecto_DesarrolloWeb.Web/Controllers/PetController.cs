using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DesarrolloWeb.Web.Models;
using Proyecto_DesarrolloWeb.Web.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreatePet()
        {
            ViewBag.petsType = await PetRepo.GetPetsTypeAsync();
            ViewBag.petsAge = await PetRepo.GetPetsAgeAsync();
            ViewBag.petsBreed = await PetRepo.GetPetsBreedAsync();
            ViewBag.petsSize = await PetRepo.GetPetsSizeAsync();

            return View();
        }

        public async Task<IActionResult> RegisterLostPet()
        {
            string idUser = HttpContext.Session.GetString("idUser");

            int userId = Convert.ToInt32(idUser);
            ViewBag.userPets = await PetRepo.GetUserPetsAsync(userId);
            return View();
        }

        public async Task<IActionResult> RegisterPetForAdoption()
        {
            string idUser = HttpContext.Session.GetString("idUser");

            int userId = Convert.ToInt32(idUser);
            ViewBag.userPetsAdoption = await PetRepo.GetUserPetsAsync(userId);
            return View();
        }

        public async Task<IActionResult> RegisterPetFound()
        {
            string idUser = HttpContext.Session.GetString("idUser");

            int userId = Convert.ToInt32(idUser);
            ViewBag.userLostPets = await PetRepo.GetUserLostPetsAsync(userId);
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Registrar(string nombre)
        //{
        //    bool exito = true;

        //    return Json(exito);
        //}

        [HttpPost]
        public async Task<IActionResult> Register (int idUser, string name, int idType, string sex, int idSize, int idAge, 
            int idBreed, string temperament, string url, List<IFormFile> files)
        {
            //INICIO - Codigo para obtener el ID del usuario
            //HttpContext.Session.SetString("idUser", "1");
        
            //FIN - Codigo para obtener el ID del usuario

            List<PetImage> petImages = new List<PetImage>();
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        byte[] fileBytes = ms.ToArray();
                        petImages.Add(new PetImage() { Photo = fileBytes });
                        string s = Convert.ToBase64String(fileBytes);
                        // act on the Base64 data
                    }
                }
            }


            var pet = new Pet()
            {
                Name = name,
                IdPetType = idType,
                Sex = sex,
                IdPetSize = idSize,
                IdPetAge = idAge,
                IdPetBreed = idBreed,
                Temperament = temperament,
                Video = url,
                PetImage = petImages,
                IdUser = idUser
            };

            bool exito = await PetRepo.RegisterPetAsync(pet);
            return Json(exito);
        }

        [HttpPost]
        public async Task<IActionResult> InsertLostPet(int idUser, int IdPet, DateTime DateLost, string Description)
        {
            //INICIO - Codigo para obtener el ID del usuario
            //HttpContext.Session.SetString("idUser", "1");
            //int idUser = 1;
            //FIN - Codigo para obtener el ID del usuario

            var lostPet = new LostPet()
            {
                IdUser = idUser,
                IdPet = IdPet,
                DateOfLoss = DateLost,
                DescriptionOfLoss = Description
            };

            var exito = await PetRepo.RegisterLostPetAsync(lostPet);
            return Json(exito);
        }
        //RegisterFoundPetAsync
        [HttpPost]
        public async Task<IActionResult> InsertFoundPet(int idUser, int IdPet, string Description, DateTime DateFound)
        {
            //INICIO - Codigo para obtener el ID del usuario
            //HttpContext.Session.SetString("idUser", "1");
            //int idUser = 1;
            //FIN - Codigo para obtener el ID del usuario

            var foundPet = new LostPet()
            {
                IdUser = idUser,
                IdPet = IdPet,
                DateOfFound = DateFound,
                DescriptionOfFound = Description
            };

            var exito = await PetRepo.RegisterFoundPetAsync(foundPet);
            return Json(exito);
        }


        [HttpPost]
        public async Task<IActionResult> InsertPetAdoption(int idUser, int IdPet, string Description)
        {
            //INICIO - Codigo para obtener el ID del usuario
            //HttpContext.Session.SetString("idUser", "1");
            //int idUser = 1;
            //FIN - Codigo para obtener el ID del usuario

            var petAdoption = new PetAdoption()
            {
                IdUser = idUser,
                IdPet = IdPet,
                Description = Description
            };

            var exito = await PetRepo.RegisterPetAdoptionAsync(petAdoption);
            return Json(exito);
        }
    }
}
