using GoogleMapsAPI.NET.API.Directions.Responses;

namespace SmartOrganizer.Timetable.Services.Directions
{
	public interface IDirectionsResponseAdapter
	{
		DirectionsResponse Adapt(GetDirectionsResponse getDirectionsResponse);
	}
}
