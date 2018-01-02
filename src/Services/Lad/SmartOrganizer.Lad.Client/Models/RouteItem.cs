using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.Lad.Client.Models
{
    [DataContract, Serializable]
    public class RouteItem
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "external_id")]
        public string ExternalId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "stops")]
        public ICollection<Stop> Stops { get; set; }
    }
}
