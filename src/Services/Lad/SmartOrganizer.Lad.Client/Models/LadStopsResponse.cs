using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.Lad.Client.Models
{
    [DataContract, Serializable]
    public class LadStopsResponse : LadResponseBase
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "timetable")]
        public ICollection<TimetableItem> Timetable { get; set; }
    }
}
