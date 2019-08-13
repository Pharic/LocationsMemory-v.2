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
        int Commit();
    }

    public class InMemoryLocationsData : ILocationData
    {
        List<Location> locations;

        public InMemoryLocationsData()
        {
            locations = new List<Location>()
            {
                new Location { Id = 1, Name = "Location #1", street_number = "1600", route = "Amphitheatre Parkway", locality = "Mountain View", administrative_area_level_2 = "Santa Clara County",
                    administrative_area_level_1 = "California", country = "United States", postal_code = "94043", postal_code_suffix = "", Latitude = "37.4221316802915", Longitude = "-122.0842816197085"},

                new Location { Id = 2, Name = "Location #2", street_number = "1601", route = "Amphitheatre Parkway", locality = "Mountain View", administrative_area_level_2 = "Santa Clara County",
                    administrative_area_level_1 = "California", country = "United States", postal_code = "94043", postal_code_suffix = "", Latitude = "37.4221316802915", Longitude = "-122.0842816197085"}
            };
        }

        public Location Update(Location updatedLocation)
        {
            var location = locations.SingleOrDefault(r => r.Id == updatedLocation.Id);
            if(location != null)
            {
                location.Name = updatedLocation.Name;
                location.street_number = updatedLocation.street_number;
                location.route = updatedLocation.route;
                location.locality = updatedLocation.locality;
                location.administrative_area_level_2 = updatedLocation.administrative_area_level_2;
                location.administrative_area_level_1 = updatedLocation.administrative_area_level_1;
                location.country = updatedLocation.country;
                location.postal_code = updatedLocation.postal_code;
                location.Latitude = updatedLocation.Latitude;
                location.Longitude = updatedLocation.Longitude;
            }
            return location;
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
