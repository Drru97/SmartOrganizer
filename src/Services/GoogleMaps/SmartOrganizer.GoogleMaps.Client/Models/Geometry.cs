using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class Geometry
    {
        [DataMember(Name = "location")]
        public Location Location { get; set; }
    }
}
