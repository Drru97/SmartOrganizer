using System;
using System.Threading.Tasks;
using Moq;
using SmartOrganizer.Timetable.Domain.Models;
using SmartOrganizer.Timetable.Services.Appointment;
using Xunit;

namespace SmartOrganizer.Services.Tests
{
    public class AppointmentServiceTests
    {
        private Mock<IAppointmentService> _appointmentService;

        public AppointmentServiceTests()
        {
            _appointmentService = new Mock<IAppointmentService>();
        }

        [Fact]
        public async Task CanGetAppointmentById()
        {
            const int id = 2;

            _appointmentService.Setup(x => x.GetAppointment(id)).ReturnsAsync(new Appointment { Id = id });

            var appointment = await _appointmentService.Object.GetAppointment(id);

            Assert.Equal(id, appointment.Id);
        }
    }
}
