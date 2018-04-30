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
    }
}
