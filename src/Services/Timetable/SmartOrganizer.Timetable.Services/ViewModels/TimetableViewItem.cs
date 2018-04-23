using System;

namespace SmartOrganizer.Timetable.Services.ViewModels
{
	public class TimetableViewItem
	{
		public string Title { get; set; }
		public string Location { get; set; }
		public string Route { get; set; }
		public DateTime DepartureTime { get; set; }
		public DateTime ArrivalTime { get; set; }
		public TimeSpan Duration { get; set; }
	}
}
