using DTO.Model;
using DAL.Context;
using DAL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AircraftRepository
    {
        public static Aircraft GetAircraft(int id)
        {
            using (AircraftContext context = new AircraftContext())
            {
                return AircraftMapper.Map(context.Aircrafts.Find(id));
            }
        }
        
        public static List<Aircraft> GetAircrafts()
        {
            using (AircraftContext context = new AircraftContext())
            {
                List<Aircraft> result = new List<Aircraft>();
                
                foreach (var s in context.Aircrafts)
                {
                    result.Add(AircraftMapper.Map(s));
                }

                return result;
            }
        }
        
        public static void AddAircraft(Aircraft aircraft, int airlineID)
        {
            using (AircraftContext context = new AircraftContext()) 
            {
                DAL.Model.Aircraft dalAircraft = AircraftMapper.Map(aircraft);
                dalAircraft.AirlineID = airlineID;
                context.Aircrafts.Add(dalAircraft);
                context.SaveChanges();
            }
        }

        public static void EditAircraft(Aircraft aircraft)
        {
            using (AircraftContext context = new AircraftContext())
            {
                Model.Aircraft dataswo = context.Aircrafts.Find(aircraft.AircraftID);
                AircraftMapper.Update(aircraft, dataswo);
                context.SaveChanges();
            }
        }

        public static void RemoveAircraft(Aircraft aircraft)
        {
            using (AircraftContext context = new AircraftContext())
            {
                Model.Aircraft dataswo = context.Aircrafts.Find(aircraft.AircraftID);
                context.Remove(dataswo);
                context.SaveChanges();
            } 
        }
        
        public static AirlineDetail GetAirline(int id)
        {
            using (AircraftContext context = new AircraftContext())
            {
                return AircraftMapper.DetailMap(context.Airlines.Include(ai => ai.Aircrafts).Where(ai => ai.AirlineID == id).First());
            }
        }
        
        public static List<Airline> GetAirlines()
        {
            using (AircraftContext context = new AircraftContext())
            {
                List<Airline> result = new List<Airline>();
                
                foreach (var ai in context.Airlines)
                {
                    result.Add(AircraftMapper.Map(ai));
                }

                return result;
            }
        }
        
        public static void AddAirline(AirlineDetail airline)
        {
            using (AircraftContext context = new AircraftContext()) 
            {
                context.Airlines.Add(AircraftMapper.DetailMap(airline));
                context.SaveChanges();
            }
        }

        public static void removeAirline(AirlineDetail airline)
        {
            using (AircraftContext context = new AircraftContext())
            {
                Model.Aircraft dataso = context.Aircrafts.Find(airline.AirlineID);
                context.Remove(dataso);
                context.SaveChanges();
            } 
        }
    }
}
