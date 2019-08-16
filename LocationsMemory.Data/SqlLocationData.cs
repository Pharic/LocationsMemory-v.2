using System.Collections.Generic;
using LocationsMemory.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocationsMemory.Data
{
    public class SqlLocationData : ILocationData
    {
        private readonly LocationsMemoryDbContext db;

        public SqlLocationData(LocationsMemoryDbContext db)
        {
            this.db = db;
        }

        public Location Add(Location newLocation)
        {
            db.Add(newLocation);
            return newLocation;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Location Delete(int id)
        {
            var location = GetById(id);
            if(location != null)
            {
                db.Locations.Remove(location);
            }
            return location;
        }

        public IEnumerable<Location> GetAll(string name)
        {
            var query =  from r in db.Locations
                         where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                         orderby r.Name
                         select r;
            return query;
        }

        public Location GetById(int id)
        {
            return db.Locations.Find(id);
        }

        public Location Update(Location updatedLocation)
        {
            var entity = db.Locations.Attach(updatedLocation);
            entity.State = EntityState.Modified;
            return updatedLocation;
        }
    }
}
