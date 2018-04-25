using System;

namespace SmartOrganizer.Timetable.Domain.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
