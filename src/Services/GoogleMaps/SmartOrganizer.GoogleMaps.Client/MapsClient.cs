using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using SmartOrganizer.GoogleMaps.Client.Models;

namespace SmartOrganizer.GoogleMaps.Client
{
    public class MapsClient : MapsClientBase
    {
        protected readonly string ApiKey;

        public MapsClient(string url, IDeserializer deserializer, string apiKey) : base(url, deserializer)
        {
            ApiKey = apiKey;
        }

        public async Task<MapsDirectionsResponse> GetDirectionsBeetweenTwoPoints(string origin, string destination)
        {
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
            {
                // TODO: implement custom exceptions
                throw new ArgumentException();
            }

            // TODO: implement modes
            const string mode = "walking";

            var request = new RestRequest("directions/json?origin={origin}&destination={destination}&mode={mode}&key={key}");

            request.AddUrlSegment("origin", origin.Replace(' ', '+'));
            request.AddUrlSegment("destination", destination.Replace(' ', '+'));
            request.AddUrlSegment("mode", mode);
            request.AddUrlSegment("key", ApiKey);

            return await GetAsync<MapsDirectionsResponse>(request);
        }

        public async Task<MapsDirectionsResponse> GetDirectionsBeetweenTwoPoints(Location origin, Location destination)
        {
            // TODO: implement validation
            if ((origin.Latitude < -90 || origin.Latitude > 90) || (origin.Longitude < -180 || origin.Longitude > 180)
                || (destination.Latitude < -90 || destination.Latitude > 90) ||
                (destination.Longitude < -180 || destination.Longitude > 180))
            {
                throw new ArgumentException();
            }

            // TODO: implement modes
            const string mode = "walking";

            var request = new RestRequest("directions/json?origin={originLat},{originLng}&destination={destLat},{destLng}&mode={mode}&key={key}");

            request.AddUrlSegment("originLat", origin.Latitude);
            request.AddUrlSegment("originLng", origin.Longitude);
            request.AddUrlSegment("destLat", destination.Latitude);
            request.AddUrlSegment("destLng", destination.Longitude);

            request.AddUrlSegment("mode", mode);
            request.AddUrlSegment("key", ApiKey);

            return await GetAsync<MapsDirectionsResponse>(request);
        }
    }
}   
