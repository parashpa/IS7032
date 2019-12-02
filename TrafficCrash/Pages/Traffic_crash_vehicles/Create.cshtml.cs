using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrafficCrash.Models;
using TrafficCrashVehicles;

namespace TrafficCrash.Pages.Traffic_crash_vehicles
{
    public class CreateModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public CreateModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrafficCrashVehicle TrafficCrashVehicle { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string Vehicle_Details = TrafficCrashVehicle.CrashUnitId + "," + TrafficCrashVehicle.RdNo + "," + TrafficCrashVehicle.UnitType + "," + TrafficCrashVehicle.VehicleId + "," + TrafficCrashVehicle.Make +
            "," + TrafficCrashVehicle.Model;
            string path = Path.Combine(_environment.ContentRootPath, "CrashDetails.txt");

            System.IO.File.AppendAllText(path, Vehicle_Details + Environment.NewLine);

            return RedirectToPage("./Index");
        }
    }
}
