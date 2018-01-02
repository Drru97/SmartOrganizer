using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.GoogleMaps.Client.Models
{
    [DataContract, Serializable]
    public class Leg
    {
        [DataMember(Name = "distance")]
        public TextValuePair Distance { get; set; }

        [DataMember(Name = "duration")]
        public TextValuePair Duration { get; set; }

        [DataMember(Name = "end_address")]
        public string EndAddress { get; set; }

        [DataMember(Name = "end_location")]
        public Location EndLocation { get; set; }

        [DataMember(Name = "start_address")]
        public string StartAddress { get; set; }

        [DataMember(Name = "start_location")]
        public Location StartLocation { get; set; }
    }   
}
