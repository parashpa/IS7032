﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TrafficCrash.Models;
using TrafficCrashPeoples;
using TrafficCrashVehicles;
using Newtonsoft.Json;

namespace TrafficCrash.Pages
{
    public class IndexModel : PageModel
    {
        public string GetData(string endpoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endpoint);
            }
            return downloadedData;
        }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public JsonResult OnGet()
        {
            List<Vehicle_People_Crash_details> vehicle_n_people = new List<Vehicle_People_Crash_details>();
            using (WebClient webClient = new WebClient())
            {
     //           string vehicleJson = webClient.DownloadString("https://data.cityofchicago.org/resource/68nd-jvt3.json");
                string vehicleJson = GetData("https://data.cityofchicago.org/resource/68nd-jvt3.json");
                TrafficCrashVehicle[] allVehicles = TrafficCrashVehicle.FromJson(vehicleJson);

                //                string peopleJson = webClient.DownloadString("https://data.cityofchicago.org/resource/u6pd-qa9d.json");
                string peopleJson = GetData("https://data.cityofchicago.org/resource/u6pd-qa9d.json");

                TrafficCrashPeople[] allPeople = TrafficCrashPeople.FromJson(peopleJson);

                IDictionary<string, TrafficCrashVehicle> trafficCrashPeople = new Dictionary<string, TrafficCrashVehicle>();

                // this new array will hold only specimens that like water.


                // iterate over the specimens, to find which ones like water.
                foreach (TrafficCrashPeople trafficCrashPeople in allPeople)
                {
                    // find the matching plant record for this specimen.
                    foreach (TrafficCrashVehicle trafficCrashVehicle in allVehicles)
                    {
                        if (trafficCrashVehicle.VehicleId == trafficCrashPeople.VehicleId)
                        {
                            var a = new Vehicle_People_Crash_details();

                            a.VehicleId = trafficCrashPeople.VehicleId;
                            a.PersonId = trafficCrashPeople.PersonId;
                            a.RdNo = trafficCrashPeople.RdNo;
                            a.CrashDate = trafficCrashPeople.CrashDate;
                            a.Sex = trafficCrashPeople.Sex;
                            a.InjuryClassification = trafficCrashPeople.InjuryClassification;
                            a.DriverVision = trafficCrashPeople.DriverVision;
                            a.PhysicalCondition = trafficCrashPeople.PhysicalCondition;
                            a.CrashUnitId = trafficCrashVehicle.CrashUnitId;
                            a.Make = trafficCrashVehicle.Make;
                            a.Model = trafficCrashVehicle.Model;

                            // we have a match!
                            vehicle_n_people.Add(a);

                        }
                    }
                }

            }

            return new JsonResult(vehicle_n_people);
        }
    }
}
