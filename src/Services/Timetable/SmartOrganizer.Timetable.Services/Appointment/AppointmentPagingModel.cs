namespace SmartOrganizer.Timetable.Services.Appointment
{
	public class AppointmentPagingModel
	{
		public int TakeRecords { get; set; } = 100;
		public int SkipRecords { get; set; }
	}
}
