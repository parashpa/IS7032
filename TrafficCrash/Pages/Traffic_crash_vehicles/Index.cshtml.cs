using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrafficCrash.Models;
using TrafficCrashVehicles;

namespace TrafficCrash.Pages.Traffic_crash_vehicles
{
    public class IndexModel : PageModel
    {
        private readonly IHostingEnvironment _environment;

        public IndexModel(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IList<TrafficCrashVehicle> TrafficCrashVehicle = new List<TrafficCrashVehicle>();
        public void OnGet()
        {
            string line;
            string path = Path.Combine(_environment.ContentRootPath, "CrashDetails.txt");
            StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                TrafficCrashVehicle fs = new TrafficCrashVehicle();
                fs.CrashUnitId = data[0];
                fs.RdNo = data[1];
                fs.UnitType = data[2];
                fs.VehicleId = data[3];
                fs.Make = data[4];
                fs.Model = data[5];

                TrafficCrashVehicle.Add(fs);
            }
            file.Close();
        }
    }
}
