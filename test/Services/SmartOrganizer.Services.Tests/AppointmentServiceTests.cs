using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SmartOrganizer.Timetable.DataAccess;
using SmartOrganizer.Timetable.Domain.Models;
using SmartOrganizer.Timetable.Services.Appointment;
using Xunit;

namespace SmartOrganizer.Services.Tests
{
    public class AppointmentServiceTests
    {
        private readonly TimetableContext _context;

        private readonly IAppointmentService _appointmentService;

        public AppointmentServiceTests()
        {
            _context = FakeTimetableContext.GetContextWithData().GetAwaiter().GetResult();
            _appointmentService = new AppointmentService(_context);
        }

        [Fact]
        public async Task CanGetAppointmentById()
        {
            const int id = 2;

            var appointment = await _appointmentService.GetAppointment(id);

            Assert.Equal(id, appointment.Id);
        }

        [Fact]
        public async Task CanGetAppointmentByFliterQuery()
        {

            //var query = new AppointmentQueryParams
            //{
            //    FromTime = new DateTime(2018, 12, 12, 0, 0, 0),
            //    ByTime = new DateTime(2018, 12, 13, 0, 0, 0)
            //};
            //var pagingModel = new AppointmentPagingModel
            //{
            //    TakeRecords = 10,
            //    SkipRecords = 0
            //};

            //var appointments = await _appointmentService.GetAppointments(query, pagingModel);
            
            //Assert.NotNull(appointments);
            //Assert.NotEmpty(appointments);
            //Assert.Equal(appointments.Single().Id, 1);
        }
    }
}
