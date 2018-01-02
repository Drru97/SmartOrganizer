using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SmartOrganizer.Lad.Client.Models
{
    [CollectionDataContract, Serializable]
    public class LadRoutesResponse : LadResponseBase
    {
        [DataMember]
        public RouteItem RouteItem { get; set; }
    }
}
