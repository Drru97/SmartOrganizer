using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class GeocodedResult
    {
        [DataMember(Name = "formatted_address")]
        public string Address { get; set; }

        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }

        [DataMember(Name = "place_id")]
        public string PlaceId { get; set; }
    }
}
