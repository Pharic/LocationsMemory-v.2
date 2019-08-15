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
        public string street_number { get; set; }
        public string route { get; set; }
        public string political { get; set; }
        public string locality { get; set; }
        public string administrative_area_level_2 { get; set; }
        public string administrative_area_level_1 { get; set; }
        public string country { get; set; }
        public string postal_code { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
