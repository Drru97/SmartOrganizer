using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;
using SmartOrganizer.Lad.Client.Models;

namespace SmartOrganizer.Lad.Client
{
    public class LadClient : LadClientBase
    {
        public LadClient(string url, IDeserializer deserializer) : base(url, deserializer) { }

        public async Task<LadStopsResponse> GetScheduleByStopId(int stopId)
        {
            var resuest = new RestRequest("stops/{stopId}");
            resuest.AddUrlSegment("stopId", stopId.ToString());

            return await GetAsync<LadStopsResponse>(resuest);
        }

        public async Task<List<LadRoutesResponse>> GetAllRoutes()
        {
            var request = new RestRequest("routes");

            return await GetAsync<List<LadRoutesResponse>>(request);
        }

        public async Task<LadRoutesResponse> GetRouteById(int routeId)
        {
            var request = new RestRequest("routes/{routeId}");
            request.AddUrlSegment("routeId", routeId.ToString());

            return await GetAsync<LadRoutesResponse>(request);
        }
    }
}
