using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class MapsGeocodedResponse
    {
        [DataMember(Name = "results")]
        public List<GeocodedResult> GeocodedResults { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
