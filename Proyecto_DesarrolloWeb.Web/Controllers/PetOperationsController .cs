using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DesarrolloWeb.Web.Models;
using Proyecto_DesarrolloWeb.Web.Repository;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Controllers
{
    public class PetOperationsController : Controller
    {

        [HttpGet]
        public ActionResult DetalleMascotaIndex(int Identification)
        {
            ViewBag.Identification = Identification;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetDetalleMascota([FromForm] Pet pet)
        {
            ResponseCustomGetDetalleMascota exito = await PetOperationsRepo.GetDetalleMascota(pet);
            return Json(exito);
        }
    }
}
