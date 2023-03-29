using BLL.BLL;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBGUI.Models;

namespace WEBGUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AircraftBLL aircraftBLL = new AircraftBLL();
            ViewBag.aircrafts = aircraftBLL.GetAircrafts();
            return View();
        }
    }
}