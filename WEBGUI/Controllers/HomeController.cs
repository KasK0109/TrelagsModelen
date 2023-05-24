using BLL.BLL;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Text.Json;
using WEBGUI.Models;

namespace WEBGUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly AircraftBLL aircraftBLL = new AircraftBLL();
        private HomeViewModel model = new HomeViewModel();

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index(string Airlines, string Aircrafts)
        {
            if(HttpContext.Session.GetString("model") == null) 
            {
                model.Airlines = new List<SelectListItem>();

                foreach (var ai in aircraftBLL.GetAirlines())
                {
                    model.Airlines.Add(new SelectListItem(ai.Name, ""+ai.AirlineID));
                }

                string json = JsonSerializer.Serialize(model);
                HttpContext.Session.SetString("model", json);
            } else
            {
                string json = HttpContext.Session.GetString("model");
                model = JsonSerializer.Deserialize<HomeViewModel>(json);
            }
            

            if (Airlines != null)
            {
                foreach (var ai in aircraftBLL.GetAirlines())
                    if ("" + ai.AirlineID == Airlines)
                    {
                        model.Aircrafts = new List<SelectListItem>();
                        foreach (var a in aircraftBLL.GetAirline(ai.AirlineID).Aircrafts)
                        {
                            model.Aircrafts.Add(new SelectListItem(a.Name, "" + a.AircraftID));
                        }
                        
                        HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
                    }
            }

            if (Aircrafts != null)
            {
                foreach (var a in aircraftBLL.GetAircrafts())
                    if (a.AircraftID == int.Parse(Aircrafts))
                    {
                        model.Aircraft = a;
                        HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
                    }
            }

            return View(model);
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(IFormCollection dataForm)
        {
            return View();
        }
    }
}