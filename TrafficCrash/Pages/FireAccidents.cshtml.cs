using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace TrafficCrash.Pages
{
    public class FireAccidentsModel : PageModel
    {
        public FireAccidents[] fireAccidents;
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {


                string fireAccidentsString = webClient.DownloadString("https://cincinnatiaccidents.azurewebsites.net/api/accidents/downtown");
                fireAccidents = FireAccidents.FromJson(fireAccidentsString);
                ViewData["fireAccidents"] = fireAccidents;

            }

        }
    }
}
