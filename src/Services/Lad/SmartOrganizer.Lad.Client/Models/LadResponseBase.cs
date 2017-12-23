using System;
using System.Runtime.Serialization;
using RestSharp;

namespace SmartOrganizer.Lad.Client.Models
{
    [DataContract, Serializable]
    public class LadResponseBase : RestResponse { }
}
