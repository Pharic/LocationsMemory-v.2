using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationsMemory.Core;
using LocationsMemory.Data;
using LocationsMemory.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocationsMemory.Pages.Locations
{
    public class EditModel : PageModel
    {
        private readonly ILocationData locationData;
        private readonly GoogleGeocodingService googleGeocodingService;

        [BindProperty]
        public Location Location { get; set; }

        public EditModel(ILocationData locationData, GoogleGeocodingService googleGeocodingService)
        {
            this.locationData = locationData;
            this.googleGeocodingService = googleGeocodingService;
        }

        public IActionResult OnGet(int? locationId)
        {
            if (locationId.HasValue)
            {
                Location = locationData.GetById(locationId.Value);
            }
            else
            {
                Location = new Location();
            }

            if(Location == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Location.Id > 0)
            {
                var googleUrl = await googleGeocodingService.GoogleApiDingens(Location);
                locationData.Update(Location);
            }
            else
            {
                var googleUrl = await googleGeocodingService.GoogleApiDingens(Location);
                locationData.Add(Location);
            }
            locationData.Commit();
            TempData["Message"] = "Location gespeichert!";
            return RedirectToPage("./Detail", new { locationId = Location.Id });
        }
    }
}