using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class GeocodedWaypoint
    {
        [DataMember(Name = "geocoder_status")]
        public string GeocoderStatus { get; set; }

        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }

        [DataMember(Name = "types")]
        public List<string> Types { get; set; }
    }
}
