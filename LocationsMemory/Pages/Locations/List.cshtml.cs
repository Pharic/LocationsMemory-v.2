using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using LocationsMemory.Data;
using LocationsMemory.Core;

namespace LocationsMemory.Pages.Locations
{
    public class ListModel : PageModel
    {
        private readonly ILocationData locationData;

        public IEnumerable<Location> Locations { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(ILocationData locationData)
        {
            this.locationData = locationData;
        }

        public void OnGet(string searchTerm)
        {
            Locations = locationData.GetAll(searchTerm);
        }
    }
}