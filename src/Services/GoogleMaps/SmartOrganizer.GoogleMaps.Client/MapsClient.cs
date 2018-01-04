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
            if ((Math.Abs(origin.Latitude) > 90 || Math.Abs(origin.Longitude) > 180)
                || (Math.Abs(destination.Latitude) > 90 || Math.Abs(destination.Longitude) > 180))
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

        public async Task<MapsGeocodedResponse> GetGeocodedAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                // TODO: implement custom exceptions
                throw new ArgumentException();
            }

            var request = new RestRequest("geocode/json?address={address}&key={key}");

            request.AddUrlSegment("address", address.Replace(' ', '+'));
            request.AddUrlSegment("key", ApiKey);

            return await GetAsync<MapsGeocodedResponse>(request);
        }

        // TODO: test this shit
        public async Task<MapsGeocodedResponse> GetGeocodedAddressByPlaceId(string placeId)
        {
            if (string.IsNullOrEmpty(placeId))
            {
                // TODO: implement custom exceptions
                throw new ArgumentException();
            }

            var request = new RestRequest("geocode/json?place_id={placeId}&key={key}");

            request.AddUrlSegment("placeId", placeId);
            request.AddUrlSegment("key", ApiKey);

            return await GetAsync<MapsGeocodedResponse>(request);
        }

        // TODO: test this shit too
        public async Task<MapsGeocodedResponse> GetGeocodedAddressByLocation(Location location)
        {
            if (Math.Abs(location.Latitude) > 90 || Math.Abs(location.Longitude) > 180)
            {
                // TODO: implement custom exceptions
                throw new ArgumentException();
            }

            var request = new RestRequest("geocode/json?latlng={lat},{lng}&key={key}");

            request.AddUrlSegment("lat", location.Latitude);
            request.AddUrlSegment("lng", location.Longitude);

            return await GetAsync<MapsGeocodedResponse>(request);
        }
    }
}
