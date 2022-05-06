using Microsoft.AspNetCore.Mvc;
using Proyecto_DesarrolloWeb.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_DesarrolloWeb.Web.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserReportAsync()
        {
            ViewBag.usersReport = await ReportRepo.GetAllUserReportAsync();
            return View();
        }
        public async Task<IActionResult> UserReportDate(DateTime startDate, DateTime endDate)
        {
            ViewBag.usersReport = await ReportRepo.GetAllUserReportAsync(startDate, endDate);
            return PartialView("TableUserReport");
        }
        public async Task<IActionResult> UserReportName(string text)
        {
            ViewBag.usersReport = await ReportRepo.GetAllUserReportAsync(text);
            return PartialView("TableUserReport");
        }

        public async Task<IActionResult> TableUserReport()
        {
            ViewBag.usersReport = await ReportRepo.GetAllUserReportAsync();
            return PartialView("TableUserReport");
        }

        public async Task<IActionResult> PetReportAsync()
        {
            ViewBag.petsType = await PetRepo.GetPetsTypeAsync();
            ViewBag.petsAge = await PetRepo.GetPetsAgeAsync();
            return View();
        }

        public async Task<IActionResult> TablePetReport()
        {
            ViewBag.petsReport = await ReportRepo.GetAllPetReportAsync(null, null, null, null, null, -1, -1);
            return PartialView("TablePetReport");
        }
        public async Task<IActionResult> TablePetReportWithData(string startDate, string endDate, string owner, string petName, string status, int idPetType, int idPetAge)
        {
            ViewBag.petsReport = await ReportRepo.GetAllPetReportAsync(
                startDate, 
                endDate, 
                owner, 
                petName, 
                status, 
                idPetType, 
                idPetAge);
            return PartialView("TablePetReport");
        }
    }
}
