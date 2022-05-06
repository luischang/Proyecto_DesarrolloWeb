using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_DesarrolloWeb.Web.Models;
using Proyecto_DesarrolloWeb.Web.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InicioSesion(string Email, string Contra)
        {
            var usuario = new Login()
            {
                UserName = Email,
                Password = Contra
            };
            ResponseCustomLogin exito = await AuthRepo.Login(usuario);
            if (exito.Code !=0)
                HttpContext.Session.SetString("idUser", exito.Data.Id.ToString());
            return Json(exito);
        }
        [HttpPost]
        public async Task<IActionResult> Registro([FromForm] User usuario)
        {
            ResponseCustom exito = await AuthRepo.Register(usuario);
            return Json(exito);
        }

    }
}
