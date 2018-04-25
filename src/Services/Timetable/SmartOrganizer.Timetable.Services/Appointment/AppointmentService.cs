using Microsoft.EntityFrameworkCore;
using SmartOrganizer.Timetable.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOrganizer.Timetable.Services.Appointment
{
	public class AppointmentService : IAppointmentService
	{
		private readonly TimetableContext _context;

		public AppointmentService(TimetableContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<IEnumerable<Domain.Models.Appointment>> GetAppointments(AppointmentQueryParams query, AppointmentPagingModel paging)
		{
			var appointments = await _context.Appointments.ToListAsync();

			if (query.FromTime.HasValue)
				appointments = appointments.Where(ap => ap.StartDate >= query.FromTime.Value).ToList();
			if (query.ByTime.HasValue)
				appointments = appointments.Where(ap => ap.EndDate <= query.ByTime.Value).ToList();

			appointments = appointments.Skip(paging.SkipRecords).Take(paging.TakeRecords).ToList();

			return appointments;
		}

		public async Task<Domain.Models.Appointment> GetAppointment(int id)
		{
			return (await _context.Appointments.Where(ap => ap.Id == id).ToListAsync()).FirstOrDefault();
		}

		public async Task AddAppointment(Domain.Models.Appointment appointment)
		{
			await _context.Appointments.AddAsync(appointment);
			await _context.SaveChangesAsync();
		}

		public async Task<Domain.Models.Appointment> UpdateAppointment(Domain.Models.Appointment appointment)
		{
			_context.Appointments.Update(appointment);
			await _context.SaveChangesAsync();

			return await _context.Appointments.FirstOrDefaultAsync(ap => ap.Id == appointment.Id);
		}

		public async Task DeleteAppointment(int id)
		{
			var item = await _context.Appointments.Where(ap => ap.Id == id).FirstOrDefaultAsync();

			if (item != null)
				_context.Appointments.Remove(item);

			await _context.SaveChangesAsync();
		}
	}
}
