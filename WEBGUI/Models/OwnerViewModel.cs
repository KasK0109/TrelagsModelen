using DTO.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBGUI.Models
{
    public class OwnerViewModel
    {
        public AirlineDetail Airline { get; set; }
        public List<SelectListItem>? Airlines { get; set; }
    }
}