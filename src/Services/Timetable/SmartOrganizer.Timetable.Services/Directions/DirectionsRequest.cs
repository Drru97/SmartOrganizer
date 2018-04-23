using GoogleMapsAPI.NET.API.Directions.Enums;
using System;

namespace SmartOrganizer.Timetable.Services.Directions
{
	public class DirectionsRequest
	{
		public string Origin { get; set; }
		public string Destination { get; set; }

		public TransportationModeEnum? TransportationMode { get; set; }

		public DateTime? DepartureTime { get; set; }
		public DateTime? ArrivalTime { get; set; }
	}
}
