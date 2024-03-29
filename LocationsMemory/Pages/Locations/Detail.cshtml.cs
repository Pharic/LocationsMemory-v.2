using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationsMemory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LocationsMemory.APIs;

namespace LocationsMemory.Pages.Locations
{
    public class DetailModel : PageModel
    {
        private readonly ILocationData locationData;

        [TempData]
        public string Message { get; set; }

        public Core.Location Location { get; set; }

        public AddressComponent AddressComponent { get; set; }

        public DetailModel(ILocationData locationData)
        {
            this.locationData = locationData;
        }

        public IActionResult OnGet(int locationId)
        {
            Location = locationData.GetById(locationId);
            if(Location == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}