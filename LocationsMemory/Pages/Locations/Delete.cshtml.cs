using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationsMemory.Core;
using LocationsMemory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LocationsMemory.Pages.Locations
{
    public class DeleteModel : PageModel
    {
        private readonly ILocationData locationData;

        public Location Location { get; set; }

        public DeleteModel(ILocationData locationData)
        {
            this.locationData = locationData;
        }

        public IActionResult OnGet(int locationId)
        {
            try
            {
                Location = locationData.GetById(locationId);
                if(Location == null)
                {
                    return RedirectToPage("./NotFound");
                }
                return Page();
                }

            catch (Exception)
            {

                throw;
            }
            
        }

        public IActionResult OnPost(int locationId)
        {
            try
            {
                var location = locationData.Delete(locationId);
                locationData.Commit();

                if (location == null)
                {
                    return RedirectToPage("./NotFound");
                }

                TempData["Message"] = $"{location.Name} wurde gelöscht!";
                return RedirectToPage("./List");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}