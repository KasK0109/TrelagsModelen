using DTO.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBGUI.Models
{
    public class HomeViewModel
    {
        public List<SelectListItem>? Aircrafts { get; set; }
        public Aircraft? Aircraft { get; set; }
        public List<SelectListItem>? Airlines { get; set; }
        public AirlineDetail? AirlineDetail { get; set;}
    }
}