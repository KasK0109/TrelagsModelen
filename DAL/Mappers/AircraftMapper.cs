using DAL.Model;

namespace DAL.Mappers;

internal class AircraftMapper
{
    public static DTO.Model.Aircraft Map(Aircraft aircraft)
    {
        return new DTO.Model.Aircraft(aircraft.AircraftID, aircraft.Name, aircraft.WingSpan, aircraft.MaxCrz);
    }
    
    public static Aircraft Map(DTO.Model.Aircraft aircraft)
    {
        return new Aircraft(aircraft.Name, aircraft.WingSpan, aircraft.MaxCrz);
    }

    internal static void Update(DTO.Model.Aircraft aircraft, Aircraft dataswo)
    {
        dataswo.Name = aircraft.Name;
        dataswo.WingSpan = aircraft.WingSpan;
        dataswo.MaxCrz = aircraft.MaxCrz;
    }

    public static DTO.Model.Airline Map(Airline airline)
    {
        DTO.Model.Airline dtoSO = new DTO.Model.Airline(airline.AirlineID);
        dtoSO.Name = airline.Name;
        return dtoSO;
    }

    public static Airline Map(DTO.Model.Airline airline)
    {
        Airline dalSO = new Airline();
        dalSO.Name = airline.Name;
        return dalSO;
    }
    
    public static DTO.Model.AirlineDetail DetailMap(Airline airline)
    {
        DTO.Model.AirlineDetail dtoSO = new DTO.Model.AirlineDetail(airline.AirlineID);
        dtoSO.Name = airline.Name;
        
        List<DTO.Model.Aircraft> list = new List<DTO.Model.Aircraft>();
        if (airline.Aircrafts != null)
        {
            foreach (Aircraft aircraft in airline.Aircrafts)
            {
                list.Add(Map(aircraft));
            }
        }

        dtoSO.Aircrafts = list;
        
        return dtoSO;
    }

    public static Airline DetailMap(DTO.Model.AirlineDetail airline)
    {
        Airline dalSO = new Airline();
        dalSO.Name = airline.Name;
        
        List<Aircraft> list = new List<Aircraft>();
        foreach (DTO.Model.Aircraft aircraft in airline.Aircrafts)
        {
            list.Add(Map(aircraft));
        }
        dalSO.Aircrafts = list;
        
        return dalSO;
    }
    
}