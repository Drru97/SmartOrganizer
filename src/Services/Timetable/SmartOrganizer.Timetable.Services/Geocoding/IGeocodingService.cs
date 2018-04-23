namespace SmartOrganizer.Timetable.Services.Geocoding
{
	public interface IGeocodingService
	{
		LatLngResult Geocode(string address);
		string ReverseGeocode(double latitude, double longitude);
	}
}
