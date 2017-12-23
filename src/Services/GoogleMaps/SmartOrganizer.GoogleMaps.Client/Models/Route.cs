using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class Route
    {
        [DataMember(Name = "bounds")]
        public Bounds Bounds { get; set; }

        [DataMember(Name = "legs")]
        public List<Leg> Legs { get; set; }
    }
}
