using GoogleMapsAPI.NET.API.Client.Interfaces;

namespace SmartOrganizer.Timetable.Services.Directions
{
	public class DirectionsService : IDirectionsService
	{
		private readonly IMapsAPIClient _client;
		private readonly IDirectionsResponseAdapter _adapter;

		public DirectionsService(IMapsAPIClient client, IDirectionsResponseAdapter adapter)
		{
			_client = client;
			_adapter = adapter;
		}

		public DirectionsResponse GetDirections(DirectionsRequest request)
		{
			if (request == null)
				return null;

			var getDirectionsResponse = _client.Directions.GetDirections(request.Origin, request.Destination,
				request.TransportationMode, departureTime: request.DepartureTime, arrivalTime: request.ArrivalTime);

			var directionsResponse = _adapter.Adapt(getDirectionsResponse);

			return directionsResponse;
		}
	}
}
