using GoogleMapsAPI.NET.API.Common.Components.Locations.Interfaces;
using GoogleMapsAPI.NET.API.Directions.Responses;
using System.Linq;
using GoogleMapsAPI.NET.API.Directions.Components;
using GoogleMapsAPI.NET.API.Directions.Enums;

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
				Duration = directionsResult.Duration.Value,
				Route = GetRouteName(directionsResult)
			};

			return response;
		}

		private static LatLngResult GetLatLngResult(IGeoCoordinatesLocation location)
		{
			return new LatLngResult(location.Latitude, location.Longitude);
		}

		private static string GetRouteName(RouteLeg routeLeg)
		{
			var transitRouteLegSteps = routeLeg.Steps.FirstOrDefault(s => s.TravelMode == TransportationModeEnum.Transit);

			if (transitRouteLegSteps == null)
				return null;

			var result = transitRouteLegSteps.TransitDetails.TransitLine.ShortName + " " +
						 transitRouteLegSteps.TransitDetails.TransitLine.Name;

			return result;
		}
	}
}
