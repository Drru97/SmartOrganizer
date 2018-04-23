using GoogleMapsAPI.NET.API.Client.Interfaces;
using System;
using System.Linq;

namespace SmartOrganizer.Timetable.Services.Geocoding
{
	public class GeocodingService : IGeocodingService
	{
		private readonly IMapsAPIClient _client;

		public GeocodingService(IMapsAPIClient client)
		{
			_client = client;
		}

		public LatLngResult Geocode(string address)
		{
			if (string.IsNullOrEmpty(address))
				return null;

			var geocodingresult = _client.Geocoding.Geocode(address).Results.Single();
			var latLngResult = new LatLngResult
			{
				Latitude = geocodingresult.Geometry.Location.Latitude,
				Longitude = geocodingresult.Geometry.Location.Longitude
			};

			return latLngResult;
		}

		public string ReverseGeocode(double latitude, double longitude)
		{
			if (Math.Abs(latitude) > 90 || Math.Abs(longitude) > 180)
				return null;

			var reverseGeocodeResult = _client.Geocoding.ReverseGeocode(latitude, longitude).Results.Single().FormattedAddress;
			return reverseGeocodeResult;
		}
	}
}
