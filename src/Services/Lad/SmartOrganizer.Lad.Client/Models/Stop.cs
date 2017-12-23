using System;
using System.Runtime.Serialization;

namespace SmartOrganizer.Lad.Client.Models
{
    [DataContract, Serializable]
    public class Stop
    {
    //    [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
