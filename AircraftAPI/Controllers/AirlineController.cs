using BLL.BLL;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;


namespace AircraftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private AircraftBLL bll = new AircraftBLL();

        [HttpGet]
        public List<AirlineDetail> airlines()
        {
            return bll.GetAirlinesDetail();
        }

        [Route("{id}")]
        [HttpGet]
        public AirlineDetail GetAirlineById(int id)
        {
            return bll.GetAirline(id);
        }

        [HttpPost]
        public void AddAirline(Airline airline)
        {
            AirlineDetail airlineDetail = new AirlineDetail();
            airlineDetail.Name = airline.Name;
            bll.AddAirline(airlineDetail);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteAirline(int id)
        {
            AirlineDetail airlineDetail = bll.GetAirline(id);

            bll.RemoveAirline(airlineDetail);
        }
    }
}
