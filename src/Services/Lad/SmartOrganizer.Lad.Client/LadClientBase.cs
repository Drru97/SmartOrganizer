using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace SmartOrganizer.Lad.Client
{
    public class LadClientBase : RestClient
    {
        protected LadClientBase(string url, IDeserializer deserializer)
        {
            AddHandler("application/json", deserializer);
        //    AddHandler("text/plain", deserializer);
            // TODO: remove hardcoded url
            BaseUrl = new Uri("https://lad.lviv.ua/api");
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

        protected async Task<List<T>> GetListAsync<T>(IRestRequest request) where T : IEnumerable, new()
        {
            var response = await ExecuteTaskAsync<T>(request);
            var result = new List<T>();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                foreach (T item in response.Data)
                {
                    result.Add(item);
                }

                return result;
            }

            return null;
        }
    }
}
