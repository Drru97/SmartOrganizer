﻿using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.Lad.Client.Models
{
    [DataContract, Serializable]
    public class TimetableItem
    {
        [DataMember(Name = "route")]
        public string Route { get; set; }

        [DataMember(Name = "full_route_name")]
        public string FullRouteName { get; set; }

        [DataMember(Name = "vehicle_type")]
        public VehicleType VehicleType { get; set; }

        [DataMember(Name = "lowfloor")]
        public bool LowFloor { get; set; }

        [DataMember(Name = "end_stop")]
        public string EndStop { get; set; }

        [DataMember(Name = "seconds_left")]
        public int SecondsLeft { get; set; }

        [DataMember(Name = "time_left")]
        public string TimeLeft { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
    }

    public enum VehicleType
    {
        Bus = 1,
        Tram = 2,
        Trol = 3
    }
}
