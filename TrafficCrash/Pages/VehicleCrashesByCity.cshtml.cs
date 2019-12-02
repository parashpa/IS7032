using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrafficCrashPeoples;
using System.Net;
using Newtonsoft.Json;

namespace TrafficCrash.Pages
{
    public class VehicleCrashesByCityModel : PageModel
    {
        public JsonResult OnGet()
        {
            string city = HttpContext.Request.Query["city"];

            string url = "https://data.cityofchicago.org/resource/u6pd-qa9d.json?";

 
                url = url + "city=" + city;

            string crashDetails = getData(url);

            TrafficCrashPeople[] array = TrafficCrashPeople.FromJson(crashDetails);

            return new JsonResult(array);

        }

        private string getData(string url)


        {


            using (WebClient webClient = new WebClient())


            {


                return webClient.DownloadString(url);


            }


        }
    }
}