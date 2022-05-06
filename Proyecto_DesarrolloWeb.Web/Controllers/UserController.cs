using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DesarrolloWeb.Web.Models;
using Proyecto_DesarrolloWeb.Web.Repository;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UsuariosAprobadosIndex()
        {
            //ViewBag.dataprueba = exito;
            return View();
        }
        public ActionResult AprobarUsuariosIndex()
        {
            //ViewBag.dataprueba = exito;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetUsersAprobados()
        {
            ResponseCustomUser exito = await UserRepo.GetUsers("aprobados");
            return Json(exito);
        }
        [HttpPost]
        public async Task<IActionResult> GetUsersDesaAprobados()
        {
            ResponseCustomUser exito = await UserRepo.GetUsers("desaprobados");
            return Json(exito);
        }
        [HttpPost]
        public async Task<IActionResult> AprobarUser([FromForm] User usuario)
        {
            ResponseCustom exito = await UserRepo.AprobarUser(usuario);
            return Json(exito);
        }
    }
}
