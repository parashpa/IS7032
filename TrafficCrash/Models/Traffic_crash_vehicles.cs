﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using TrafficCrash;
//
//    var trafficCrashVehicle = TrafficCrashVehicle.FromJson(jsonString);

namespace TrafficCrashVehicles
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class TrafficCrashVehicle
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [Required]
        [JsonProperty("crash_unit_id")]
        public string CrashUnitId { get; set; }


        [Required]
        [JsonProperty("rd_no")]
        public string RdNo { get; set; }

        [Required]
        [JsonProperty("crash_date")]
        public DateTimeOffset CrashDate { get; set; }

        [Required]
        [JsonProperty("unit_no")]
        public string UnitNo { get; set; }

        [Required]
        [JsonProperty("unit_type")]
        public string UnitType { get; set; }

        [Required]
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [Required]
        [JsonProperty("lic_plate_state")]
        public string LicPlateState { get; set; }

        [JsonProperty("vehicle_defect")]
        public string VehicleDefect { get; set; }

        [JsonProperty("vehicle_type")]
        public string VehicleType { get; set; }

        [JsonProperty("vehicle_use")]
        public string VehicleUse { get; set; }

        [Required]
        [JsonProperty("travel_direction")]
        public string TravelDirection { get; set; }

        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }

        [JsonProperty("occupant_cnt")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OccupantCnt { get; set; }

        [JsonProperty("area_12_i")]
        public string Area12_I { get; set; }

        [JsonProperty("first_contact_point")]
        public string FirstContactPoint { get; set; }
    }

    public partial class TrafficCrashVehicle
    {
        public static TrafficCrashVehicle[] FromJson(string json) => JsonConvert.DeserializeObject<TrafficCrashVehicle[]>(json, TrafficCrashVehicles.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TrafficCrashVehicle[] self) => JsonConvert.SerializeObject(self, TrafficCrashVehicles.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
