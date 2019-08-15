using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LocationsMemory.Core
{
    public class Location
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }
        public string Street_number { get; set; }
        public string Street_name { get; set; }
        public string City { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
