using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DAL.Context
{
    internal class AircraftContext : DbContext
    {
        public AircraftContext()
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SAM\\SQLEXPRESS;Initial Catalog=Aircraft;Integrated Security=SSPI; TrustServerCertificate=true");
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Airline ai1;
            Airline ai2;
            Aircraft a1;
            Aircraft a2;
            Aircraft a3;
            //<New>
            modelBuilder.Entity<Airline>()
                .HasMany(b => b.Aircrafts)
                .WithOne();
            //</New>
            modelBuilder.Entity<Airline>().HasData(new Airline[] {
                
                ai1 = new Airline(){AirlineID= -1,Name="Scandinavian Airlines System"},
                ai2 = new Airline(){AirlineID = -2, Name = "Widerøe"},
                new Airline(){AirlineID = -3, Name = "Danish Air Transport"}
            });
            modelBuilder.Entity<Aircraft>().HasData(new Aircraft[] {
                a1 = new Aircraft(){AircraftID= -1,Name="Airbus A350-900", WingSpan = 65, MaxCrz = 43000, AirlineID = -1},
                a2 = new Aircraft(){AircraftID= -2,Name="Airbus A320N", WingSpan = 35.8, MaxCrz = 40000, AirlineID = -1},
                a3 = new Aircraft(){AircraftID= -3,Name="Airbus A330-300", WingSpan = 60, MaxCrz = 41000, AirlineID = -1}
            });
            
        }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airline> Airlines { get; set; }
    }
}
