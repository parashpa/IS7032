using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrafficCrashPeoples;

namespace TrafficCrash.Models
{
    public class Vehicle_People_Crash_details
    {
        [JsonProperty("vehicle_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long VehicleId { get; set; }

        [JsonProperty("person_id")]
        public string PersonId { get; set; }

        [JsonProperty("rd_no")]
        public string RdNo { get; set; }

        [JsonProperty("crash_date")]
        public DateTimeOffset CrashDate { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("injury_classification")]
        public string InjuryClassification { get; set; }


        [JsonProperty("driver_vision")]
        public string DriverVision { get; set; }

        [JsonProperty("physical_condition")]
        public string PhysicalCondition { get; set; }

        [JsonProperty("crash_unit_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CrashUnitId { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }


    }
}
