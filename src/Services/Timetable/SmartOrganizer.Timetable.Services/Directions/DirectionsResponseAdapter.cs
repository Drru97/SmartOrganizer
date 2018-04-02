using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Directions.Responses;
using System.Linq;

namespace SmartOrganizer.Timetable.Services.Directions
{
	public class DirectionsResponseAdapter : IDirectionsResponseAdapter
	{
		public DirectionsResponse Adapt(GetDirectionsResponse getDirectionsResponse)
		{
			var directionsResult = getDirectionsResponse?.Routes.FirstOrDefault()?.Legs.FirstOrDefault();

			if (directionsResult == null)
				return null;

			var response = new DirectionsResponse
			{
				Origin = GetLatLngResult(directionsResult.StartLocation),
				Destination = GetLatLngResult(directionsResult.EndLocation),
				Distnance = directionsResult.Distance.Value,
				Duration = directionsResult.Duration.Value
			};

			return response;
		}

		private static LatLngResult GetLatLngResult(IGeoCoordinatesLocation location)
		{
			return new LatLngResult(location.Latitude, location.Longitude);
		}
	}
}
