namespace DAL.Model;

internal class Aircraft
{
    public Aircraft(string name, double wingSpan, double maxCrz)
    {
        Name = name;
        WingSpan = wingSpan;
        MaxCrz = maxCrz;
    }

    public Aircraft(int aircraftID, string name, double wingSpan, double maxCrz)
    {
        AircraftID = aircraftID;
        Name = name;
        WingSpan = wingSpan;
        MaxCrz = maxCrz;
    }
    public Aircraft()
    {
    }

    public int AircraftID { get; set; }
    public string Name { get; set; }
    public double WingSpan { get; set; }
    public double MaxCrz { get; set; }
    public int AirlineID { get; set; }

    public override string ToString()
    {
        return Name;
    }
}