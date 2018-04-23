using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartOrganizer.Timetable.Services.Appointment
{
	public interface IAppointmentService
	{
		Task<IEnumerable<DataAccess.Models.Appointment>> GetAppointments();
		Task<DataAccess.Models.Appointment> GetAppointment(int id);
		Task AddAppointment(DataAccess.Models.Appointment appointment);
		Task<DataAccess.Models.Appointment> UpdateAppointment(DataAccess.Models.Appointment appointment);
		Task DeleteAppointment(int id);
	}
}