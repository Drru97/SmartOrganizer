using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartOrganizer.Timetable.DataAccess;
using SmartOrganizer.Timetable.Domain.Models;

namespace SmartOrganizer.Services.Tests
{
    public class FakeTimetableContext
    {
        public static async Task<TimetableContext> GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<TimetableContext>()
                .UseInMemoryDatabase().Options;
            
            var context = new TimetableContext(options);

            var appointment1 = new Appointment()
            {
                Id = 1,
                Title = "Beer party",
                Location = "Lviv",
                Description = "no description",
                StartDate = new DateTime(2018, 12, 12, 0, 0, 0),
                EndDate = new DateTime(2018, 12, 12, 23, 0, 0),
                CreationDate = DateTime.Now
            };
            var appointment2 = new Appointment
            {
                Id = 2
            };
            
            await context.Appointments.AddRangeAsync(appointment1, appointment2);
            await context.SaveChangesAsync();

            return context;
        }
    }
}