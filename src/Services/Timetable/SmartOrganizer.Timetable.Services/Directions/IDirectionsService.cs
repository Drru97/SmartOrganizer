namespace SmartOrganizer.Timetable.Services.Directions
{
	public interface IDirectionsService
	{
		DirectionsResponse GetDirections(DirectionsRequest request);
	}
}
