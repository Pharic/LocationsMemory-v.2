using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LocationsMemory.Core;

namespace LocationsMemory.Data
{
    public class LocationsMemoryDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
    }
}
