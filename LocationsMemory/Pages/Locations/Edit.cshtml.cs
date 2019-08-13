using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationsMemory.Core;
using LocationsMemory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationsMemory.Pages.Locations
{
    public class EditModel : PageModel
    {
        private readonly ILocationData locationData;

        [BindProperty]
        public Location Location { get; set; }

        public EditModel(ILocationData locationData)
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                locationData.Update(Location);
                locationData.Commit();
                return RedirectToPage("./Detail", new { locationId = Location.Id });
            }
            return Page();
        }
    }
}