namespace DAL.Model;

internal class Airline
{
    private List<Aircraft> _aircrafts;
    private string name;
    
    public virtual List<Aircraft> Aircrafts
    {
        get { return _aircrafts; }
        set { _aircrafts = value; }
    }
    
    public int AirlineID { get; set; }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}