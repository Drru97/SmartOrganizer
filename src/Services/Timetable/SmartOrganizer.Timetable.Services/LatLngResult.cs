namespace SmartOrganizer.Timetable.Services
{
	public class LatLngResult
	{
		public LatLngResult() { }

		public LatLngResult(double lat, double lng)
		{
			Latitude = lat;
			Longitude = lng;
		}

		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
