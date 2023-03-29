using System.ComponentModel.DataAnnotations;

namespace DTO.Model;

public class Aircraft
{
    public Aircraft(int aircraftID, string name, double wingSpan, double maxCrz)
    {
        AircraftID = aircraftID;
        Name = name;
        WingSpan = wingSpan;
        MaxCrz = maxCrz;
    }
    public Aircraft(string name, double wingSpan, double maxCrz)
    {
        Name = name;
        WingSpan = wingSpan;
        MaxCrz = maxCrz;
    }
    
    public int AircraftID { get; set; }
    [Required]
    public string Name { get; set; }
    public double WingSpan { get; set; }
    public double MaxCrz { get; set; }

    public override string ToString()
    {
        return Name;
    }
}