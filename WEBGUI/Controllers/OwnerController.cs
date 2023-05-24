using DTO.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using WEBGUI.Models;

namespace WEBGUI.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {

            HttpClient client = new HttpClient();
            var stringTask = client.GetStringAsync("https://localhost:7251/api/Airline");
            var msg = stringTask.Result;
            Console.WriteLine(msg);
            var air = JsonSerializer.Deserialize<List<AirlineDetail>>(msg);
            Console.WriteLine(air);

            OwnerViewModel model = new OwnerViewModel();
            model.Airlines = new List<SelectListItem>();
            
            foreach(var ai in air)
            {
                Console.WriteLine("added " + ai.Name);
                model.Airlines.Add(new SelectListItem(ai.Name, ""+ai.AirlineID));
            }


            return View(model);
        }
    }
}
