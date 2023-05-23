using DAL.Repositories;
using DTO.Model;

namespace BLL.BLL;

public class AircraftBLL
{
    // Aircraft
    
    public Aircraft GetAircraft(int id)
    {
        return AircraftRepository.GetAircraft(id);
    }

    public List<Aircraft> GetAircrafts()
    {
        return AircraftRepository.GetAircrafts();
    }

    public void AddAircraft(Aircraft aircraft, int airlineID)
    {
        AircraftRepository.AddAircraft(aircraft, airlineID);
    }
    
    public void EditAircraft(Aircraft aircraft)
    {
        AircraftRepository.EditAircraft(aircraft);
    }

    public void RemoveAircraft(Aircraft aircraft)
    {
        AircraftRepository.RemoveAircraft(aircraft);
    }
    
    // AIRLINES
    
    public AirlineDetail GetAirline(int id)
    {
        return AircraftRepository.GetAirline(id);
    }

    public List<Airline> GetAirlines()
    {
        return AircraftRepository.GetAirlines();
    }

    public List<AirlineDetail> GetAirlinesDetail()
    {
        return AircraftRepository.GetAirlinesDetail();
    }

    public void AddAirline(AirlineDetail airline)
    {
        AircraftRepository.AddAirline(airline);
    }
    
    public void RemoveAirline(AirlineDetail airline)
    {
        AircraftRepository.removeAirline(airline);
    }
    
}