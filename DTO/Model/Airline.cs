using System.ComponentModel.DataAnnotations;

namespace DTO.Model;

public class Airline
{
    public Airline(int airlineId)
    {
        AirlineID = airlineId;
    }

    public Airline()
    {
    }

    public int AirlineID { get; set; }
    [Required]
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}