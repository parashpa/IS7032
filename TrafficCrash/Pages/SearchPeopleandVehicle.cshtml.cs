using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrafficCrashPeoples;
using TrafficCrashVehicles;

namespace TrafficCrash.Pages
{
    public class SearchPeopleandVehicleModel : PageModel
    {
        public bool SearchCompleted;
        [BindProperty]
        public string Search { get; set; }

        public void OnGet()
        {
            SearchCompleted = false;

        }



        public void OnPost()

        {
            using (var webClient = new WebClient())
            {
                string vehicleJson = webClient.DownloadString("https://data.cityofchicago.org/resource/68nd-jvt3.json");
                TrafficCrashVehicle[] allVehicles = TrafficCrashVehicle.FromJson(vehicleJson);

                string peopleJson = webClient.DownloadString("https://data.cityofchicago.org/resource/u6pd-qa9d.json");
                TrafficCrashPeople[] allPeople = TrafficCrashPeople.FromJson(peopleJson);

                allVehicles = allVehicles.Where(x => x.RdNo.ToUpper().Equals(Search.ToUpper())).ToArray();
                ViewData["allVehicles"] = allVehicles;

                allPeople = allPeople.Where(x => x.RdNo.ToUpper().Equals(Search.ToUpper())).ToArray();
                ViewData["allPeople"] = allPeople;


                SearchCompleted = true;
            }
        }
    }
}