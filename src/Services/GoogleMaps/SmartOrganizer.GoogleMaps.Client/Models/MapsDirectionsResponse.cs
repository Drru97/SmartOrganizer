using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class MapsDirectionsResponse
    {
        [DataMember(Name = "geocoded_waypoints")]
        public List<GeocodedWaypoint> GeocodedWaypoints { get; set; }

        [DataMember(Name = "routes")]
        public List<Route> Routes { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
