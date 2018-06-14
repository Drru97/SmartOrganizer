using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartOrganizer.Timetable.Services.Appointment
{
	public class FakeAppointmentService : IAppointmentService
	{
		private static readonly IList<Domain.Models.Appointment> _appointments;

		static FakeAppointmentService()
		{
			_appointments = new List<Domain.Models.Appointment>
			{
				new Domain.Models.Appointment
				{
					Id = 1,
					Title = "Похід в Карпати",
					Location = "Славське",
					Description = "Похід в гори",
					CreationDate = DateTime.Now,
					StartDate = new DateTime(2018, 7, 6, 15, 30, 0),
					EndDate = new DateTime(2018, 7, 9, 8, 0, 0)
				},
				new Domain.Models.Appointment
				{
					Id = 2,
					Title = "Концерт Imagine Dragons",
					Location = "Київ, НСК Олімпійський",
					Description = "Концерт групи Imagine Dragons у Києві",
					CreationDate = DateTime.Now,
					StartDate = new DateTime(2018, 8, 31, 20, 0, 0),
					EndDate = new DateTime(2018, 8, 31, 22, 0, 0)
				},
				new Domain.Models.Appointment
				{
					Id = 3,
					Title = "Захист диплому",
					Location = "Драгоманова, 50, Львів",
					Description = "Захист бакалаврських робіт у групи ФеІ-41",
					CreationDate = DateTime.Now,
					StartDate = new DateTime(2018, 6, 20, 11, 0, 0),
					EndDate = new DateTime(2018, 6, 20, 13, 0, 0)
				},
				new Domain.Models.Appointment
				{
					Id = 4,
					Title = "ZaxidFest",
					Location = "Родатичі, Львівська область",
					Description = "Фестиваль ZaxidFest",
					CreationDate = DateTime.Now,
					StartDate = new DateTime(2018, 8, 24, 14, 0, 0),
					EndDate = new DateTime(2018, 8, 27, 6, 0, 0)
				},
				new Domain.Models.Appointment
				{
					Id = 5,
					Title = ".NET Community Meetup",
					Location = "Binary Studio, Львів",
					Description = "Чергова зустріч львівської .NET спільноти",
					CreationDate = DateTime.Now,
					StartDate = new DateTime(2018, 6, 29, 19, 30, 0),
					EndDate = new DateTime(2018, 6, 29, 22, 0, 0)
				}
			};
		}

		public Task<IEnumerable<Domain.Models.Appointment>> GetAppointments(AppointmentQueryParams query, AppointmentPagingModel paging)
		{
			return Task.FromResult((IEnumerable<Domain.Models.Appointment>)_appointments);
		}

		public Task<Domain.Models.Appointment> GetAppointment(int id)
		{
			return Task.FromResult(_appointments.Single(ap => ap.Id == id));
		}

		public Task AddAppointment(Domain.Models.Appointment appointment)
		{
			_appointments.Add(appointment);
			return Task.CompletedTask;
		}

		public Task<Domain.Models.Appointment> UpdateAppointment(Domain.Models.Appointment appointment)
		{
			var item = _appointments.Single(ap => ap.Id == appointment.Id);

			if (item != null)
			{
				item.Title = appointment.Title;
				item.Description = appointment.Description;
				item.Location = appointment.Location;
				item.StartDate = appointment.StartDate;
				item.EndDate = appointment.EndDate;
			}

			return Task.FromResult(item);
		}

		public Task DeleteAppointment(int id)
		{
			var item = _appointments.Single(ap => ap.Id == id);

			if (item != null)
			{
				_appointments.Remove(item);
			}

			return Task.CompletedTask;
		}
	}
}
