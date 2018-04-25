namespace SmartOrganizer.Timetable.Services.Directions
{
	public class DirectionsResponse
	{
		public LatLngResult Origin { get; set; }
		public LatLngResult Destination { get; set; }

		public long Duration { get; set; }
		public int Distnance { get; set; }

		public string Route { get; set; }
		public string Title { get; set; }
	}
}
