using System;
using System.Collections.Generic;
using LocationsMemory.Core;
using System.Text;
using Microsoft.CodeAnalysis;

namespace LocationsMemory.Data
{
    public interface ILocationsMemory
    {
        IEnumerable<Location> GetAll();
    }

    public class InMemoryLocationsData : ILocationsMemory
    {
        List<Location> locations;

        public InMemoryLocationsData()
        {
            locations = new List<Location>()
            {
                new Location { Id = 1, Name = "Byte5", Address = "Frankfurt, Hanauerlandstraße 114"}
            };
        }

        public IEnumerable<Location> GetAll()
        {

        }
    }
}
