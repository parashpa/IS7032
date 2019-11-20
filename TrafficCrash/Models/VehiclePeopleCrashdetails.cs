using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrafficCrashPeoples;

namespace TrafficCrash.Models
{
    public class VehiclePeopleCrashdetails
    {

        private long vehicle_id;
        private string person_id;
        private string rd_no;
        private DateTimeOffset crash_date;
        private string sex;
        private string injury_classification;
        private string driver_vision;
        private string physical_condition;
        private long crash_unit_id;
        private string make;
        private string model;


        [JsonProperty("vehicle_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        [Required]
        public long VehicleId { get => vehicle_id; set => vehicle_id = value; }

        [JsonProperty("person_id")]
        [Required]
        public string PersonId { get => person_id; set => person_id = value; }

        [JsonProperty("rd_no")]
        public string RdNo { get => rd_no; set => rd_no = value; }

        [JsonProperty("crash_date")]
        public DateTimeOffset CrashDate { get => crash_date; set => crash_date = value; }

        [JsonProperty("sex")]
        public string Sex { get => sex; set => sex = value; }

        [JsonProperty("injury_classification")]
        public string InjuryClassification { get => injury_classification; set => injury_classification = value; }


        [JsonProperty("driver_vision")]
        public string DriverVision { get => driver_vision; set => driver_vision = value; }

        [JsonProperty("physical_condition")]
        public string PhysicalCondition { get => physical_condition; set => physical_condition = value; }

        [JsonProperty("crash_unit_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CrashUnitId { get => crash_unit_id; set => crash_unit_id = value; }

        [JsonProperty("make")]
        public string Make { get => make; set => make = value; }

        [JsonProperty("model")]
        public string Model { get => model; set => model = value; }


    }
}
