using System;
using System.Collections.Generic;
using LocationsMemory.Core;
using System.Text;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace LocationsMemory.Data
{
    public interface ILocationData
    {
        IEnumerable<Location> GetAll();
        Location GetById(int id);
        Location Update(Location updatedLocation);
        Location Add(Location newLocation);
        int Commit();
    }

    public class InMemoryLocationsData : ILocationData
    {
        List<Location> locations;

        public InMemoryLocationsData()
        {
            locations = new List<Location>()
            {
                new Location { Id = 1, Name = "Location #1", Street_number = "1600", Street_name = "Amphitheatre Parkway", City = "Mountain View"},

                new Location { Id = 2, Name = "Byte5", Street_number = "114", Street_name = "Hanauer Landstraße", City = "Frankfurt am Main"}
            };
        }

        public Location Update(Location updatedLocation)
        {
            var location = locations.SingleOrDefault(r => r.Id == updatedLocation.Id);
            if(location != null)
            {
                location.Name = updatedLocation.Name;
                location.Street_number = updatedLocation.Street_number;
                location.Street_name = updatedLocation.Street_name;
                location.City = updatedLocation.City;

            }
            return location;
        }
        public Location Add(Location newLocation)
        {
            locations.Add(newLocation);
            newLocation.Id = locations.Max(r => r.Id) + 1;
            return newLocation;
        }

        public int Commit()
        {
            return 0;
        }

        public Location GetById(int id)
        {
            return locations.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Location> GetAll()
        {
            return from r in locations
                   orderby r.Name
                   select r;
        }
    }
}
