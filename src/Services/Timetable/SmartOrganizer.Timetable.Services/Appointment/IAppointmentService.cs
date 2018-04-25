using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartOrganizer.Timetable.Services.Appointment
{
	public interface IAppointmentService
	{
		Task<IEnumerable<Domain.Models.Appointment>> GetAppointments(AppointmentQueryParams query, AppointmentPagingModel paging);
		Task<Domain.Models.Appointment> GetAppointment(int id);
		Task AddAppointment(Domain.Models.Appointment appointment);
		Task<Domain.Models.Appointment> UpdateAppointment(Domain.Models.Appointment appointment);
		Task DeleteAppointment(int id);
	}
}
