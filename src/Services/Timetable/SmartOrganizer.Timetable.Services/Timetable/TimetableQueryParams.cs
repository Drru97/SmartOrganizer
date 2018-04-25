using System;

namespace SmartOrganizer.Timetable.Services.Timetable
{
	public class TimetableQueryParams
	{
		public DateTime? StartFrom { get; set; }
		public DateTime? EndBy { get; set; }

		public int TakeRecords { get; set; } = 100;
		public int SkipRecords { get; set; }
	}
}
