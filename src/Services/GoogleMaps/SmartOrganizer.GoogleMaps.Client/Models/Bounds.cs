using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class Bounds
    {
        [DataMember(Name = "northeast")]
        public Location Northeast { get; set; }

        [DataMember(Name = "southwest")]
        public Location Southwest { get; set; }
    }
}
