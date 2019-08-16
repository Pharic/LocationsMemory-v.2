using System;
using System.Collections.Generic;
using LocationsMemory.Core;
using System.Text;
using Microsoft.CodeAnalysis;

namespace LocationsMemory.Data
{
    public interface ILocationData
    {
        IEnumerable<Location> GetAll(string name);
        Location GetById(int id);
        Location Update(Location updatedLocation);
        Location Add(Location newLocation);
        Location Delete(int id);
        int Commit();
    }
}
