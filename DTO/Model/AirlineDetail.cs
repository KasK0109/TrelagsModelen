using System.ComponentModel.DataAnnotations;

namespace DTO.Model;

public class AirlineDetail
{
    public AirlineDetail(int airlineId)
    {
        AirlineID = airlineId;
        Aircrafts = new List<Aircraft>();
    }

    public AirlineDetail()
    {
        Aircrafts = new List<Aircraft>();
    }


    public int AirlineID { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Aircraft> Aircrafts { get; set; }
}