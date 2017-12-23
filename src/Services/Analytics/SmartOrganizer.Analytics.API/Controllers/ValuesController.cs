using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartOrganizer.GoogleMaps.Client;
using SmartOrganizer.GoogleMaps.Client.Models;
using SmartOrganizer.Lad.Client;

namespace SmartOrganizer.Analytics.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
    //        var client = new LadClient("https://lad.lviv.ua/api", new JsonSerializer());
   //         var response = await client.GetAllRoutes();

            var mapsClient = new MapsClient("https://maps.googleapis.com/maps/api/", new JsonSerializer(), "AIzaSyCX780yRIpZYmbfQaE4imqJZQ9rCyar5mw");
            var response = await mapsClient.GetDirectionsBeetweenTwoPoints(new Location(49.842694, 24.001365), new Location(49.841601, 24.015784));

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
