using System;

namespace SmartOrganizer.Timetable.Services.Appointment
{
	public class AppointmentQueryParams
	{
		public DateTime? FromTime { get; set; }
		public DateTime? ByTime { get; set; }
	}
}
