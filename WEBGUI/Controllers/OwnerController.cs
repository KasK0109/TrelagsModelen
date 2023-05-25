using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Text.Json;
using WEBGUI.Models;

namespace WEBGUI.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {

            var client = new HttpClient();
            var stringTask = client.GetStringAsync("https://localhost:7251/api/Airline");
            var msg = stringTask.Result;
            var air = JsonSerializer.Deserialize<List<AirlineDetail>>(msg);
            
            var model = new OwnerViewModel();
            model.Airlines = new List<SelectListItem>();

            foreach (var ai in air)
            {
                Console.WriteLine("added " + ai.Name);
                model.Airlines.Add(new SelectListItem(ai.Name, ""+ai.AirlineID));
            }

            return View(model);
        }

        [HttpPost]

        public IActionResult Index(IFormCollection dataForm, string submit)
        {
            var client = new HttpClient();

            switch(submit)
            {
                case "Add":
                    var ai = new AirlineDetail();
                    ai.Name = dataForm["Airline.Name"];
                    var jsonPayload = JsonSerializer.Serialize(ai);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                    var res1 = client.PostAsync("https://localhost:7251/api/Airline", content);
                    Console.WriteLine(res1.Result);
                    break;
                case "Delete":
                    var stringTask = client.GetStringAsync("https://localhost:7251/api/Airline" + dataForm["Airline.AirlineID"]);
                    var msg = stringTask.Result;
                    var airline = JsonSerializer.Deserialize<AirlineDetail>(msg);

                    if(airline.Aircrafts.Count < 1)
                    {
                        var res2 = client.DeleteAsync("https://localhost:7251/api/Airline" + dataForm["Airline.AirlineID"]);
                        Console.WriteLine(res2.Result);
                    } else
                    {
                        client.Dispose();
                        return Redirect("https://localhost:7273/Owner/Index" + dataForm["Airline.AirlineID"]);
                    }
                    break;
            }

            client.Dispose();
            return Redirect("https://localhost:7273/Owner/Index");

        }
    }
}
