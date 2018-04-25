using System.Threading.Tasks;
using SmartOrganizer.Timetable.Services.ViewModels;

namespace SmartOrganizer.Timetable.Services.Timetable
{
	public interface ITimetableService
	{
		Task<TimetableViewModel> GetTimetable(TimetableQueryParams query);
	}
}
