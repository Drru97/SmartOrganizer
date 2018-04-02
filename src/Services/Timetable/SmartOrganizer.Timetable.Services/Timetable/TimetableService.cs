using SmartOrganizer.Timetable.Services.Directions;
using SmartOrganizer.Timetable.Services.ViewModels;

namespace SmartOrganizer.Timetable.Services.Timetable
{
	public class TimetableService : ITimetableService
	{
		private readonly IDirectionsService _directionsService;

		public TimetableService(IDirectionsService directionsService)
		{
			_directionsService = directionsService;
		}

		public TimetableViewModel GetTimetable()
		{
			return null;
		}
	}
}
