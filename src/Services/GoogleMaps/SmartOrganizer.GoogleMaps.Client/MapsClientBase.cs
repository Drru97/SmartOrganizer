using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace SmartOrganizer.GoogleMaps.Client
{
    public class MapsClientBase : RestClient
    {
        protected MapsClientBase(string url, IDeserializer deserializer)
        {
            AddHandler("application/json", deserializer);
            // TODO: remove hardcoded url
            BaseUrl = new Uri("https://maps.googleapis.com/maps/api/");
        }

        public override async Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync(request);
            return response;
        }

        public override async Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            var response = await base.ExecuteTaskAsync<T>(request);
            return response;
        }

        protected async Task<T> GetAsync<T>(IRestRequest request) where T : new()
        {
            var response = await ExecuteTaskAsync<T>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }

            return default(T);
        }
    }
}
